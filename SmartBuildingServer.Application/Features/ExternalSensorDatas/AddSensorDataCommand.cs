using ED.GenericRepository;
using ED.Result;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SmartBuildingServer.Domain.Logs;
using SmartBuildingServer.Domain.Repositories;
using System.Globalization;

namespace SmartBuildingServer.Application.Features.ExternalSensorDatas;

public sealed record AddSensorDataCommand(
    Guid RoomId,
    Guid DeviceId,
    List<IFormFile> Files) : IRequest<Result<string>>;

internal sealed class AddSensorDataCommandHandler(
    IRoomRepository roomRepository,
    IDeviceRepository deviceRepository,
    ISensorDataRepository sensorDataRepository, // Eğer history repo üzerinden ekleme yapacaksanız buna ihtiyaç kalmayabilir ama şimdilik tutuyorum.
    ISensorDataHistoryRepository sensorDataHistoryRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<AddSensorDataCommand, Result<string>>
{
    public async Task<Result<string>> Handle(AddSensorDataCommand request, CancellationToken cancellationToken)
    {
        var room = await roomRepository.GetByExpressionAsync(r => r.Id == request.RoomId, cancellationToken);
        if (room is null)
            return Result<string>.Failure("Room not found");

        // Cihazı ve ona bağlı sensörleri getiriyoruz
        var device = await deviceRepository.Where(d => d.Id == request.DeviceId)
                                     .Include(w => w.SensorDatas)
                                     .FirstOrDefaultAsync(cancellationToken);
        if (device is null)
            return Result<string>.Failure("Device not found");

        if (device.SensorDatas is null || !device.SensorDatas.Any())
            return Result<string>.Failure("Device has no registered sensors");

        var historyRecordsToInsert = new List<SensorDataHistory>();

        foreach (var file in request.Files)
        {
            if (file.Length == 0) continue;

            using var stream = file.OpenReadStream();
            using var reader = new StreamReader(stream);

            // 1. İlk satırı (Header) oku
            string? headerLine = await reader.ReadLineAsync(cancellationToken);
            if (string.IsNullOrWhiteSpace(headerLine)) continue;

            var headers = headerLine.Split(',');

            // 2. Sütun İndeksi ile SensorDataId'yi eşleştiren sözlük
            var columnIndexToSensorId = new Dictionary<int, Guid>();
            for (int i = 1; i < headers.Length; i++)
            {
                var csvColumnName = headers[i].Trim();
                var matchedSensor = device.SensorDatas.FirstOrDefault(s =>
                    s.DataName.Equals(csvColumnName, StringComparison.OrdinalIgnoreCase));

                if (matchedSensor is not null)
                {
                    columnIndexToSensorId[i] = matchedSensor.Id;
                }
            }

            if (!columnIndexToSensorId.Any()) continue;

            // 3. Kalan veri satırlarını oku ve işle
            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync(cancellationToken);
                if (string.IsNullOrWhiteSpace(line)) continue;

                var columns = line.Split(',');
                if (columns.Length < 2) continue;

                // Timestamp (Tarih) parse et (0. indeks)
                if (!DateTime.TryParse(columns[0].Trim(), CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                {
                    continue;
                }

                DateTime utcDate = parsedDate.ToUniversalTime();

                // Sütunları gez ve History kaydı oluştur
                for (int i = 1; i < columns.Length; i++)
                {
                    if (columnIndexToSensorId.TryGetValue(i, out Guid sensorId))
                    {
                        string stringValue = columns[i].Trim();

                        if (double.TryParse(stringValue, NumberStyles.Any, CultureInfo.InvariantCulture, out double parsedValue))
                        {
                            var historyRecord = new SensorDataHistory
                            {
                                SensorDataId = sensorId,
                                Value = parsedValue,
                                CreatedAt = utcDate // Entity base class'ı eziyoruz
                            };

                            historyRecordsToInsert.Add(historyRecord);
                        }
                    }
                }
            }
        }

        // 4. Veritabanına kaydet (ED.GenericRepository uyumlu kısım)
        if (historyRecordsToInsert.Any())
        {
            // AddRange olmadığı için döngü ile her birini AddAsync yapıyoruz.
            // SaveChanges en son çağrıldığı için EF Core arka planda batch işlemi yapacaktır.
            foreach (var record in historyRecordsToInsert)
            {
                await sensorDataHistoryRepository.AddAsync(record, cancellationToken);
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<string>.Succeed($"{historyRecordsToInsert.Count} sensor history records successfully added.");
        }

        return Result<string>.Failure("No valid data found to process.");
    }
}