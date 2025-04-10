using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Rooms;

namespace SmartBuildingServer.Application.Features.Rooms.UpdateRoom;
internal sealed class UpdateRoomCommandHandler(
    IRoomRepository roomRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateRoomCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        Room room = await roomRepository.GetByExpressionAsync(g => g.Id == request.Id, cancellationToken: cancellationToken);
        if (room is null)
        {
            return Result<string>.Failure("Oda bulunamadı");
        }

        var isRoomExists = roomRepository.GetByExpression(g => g.RoomName == request.RoomName && g.AppUserId == room.AppUserId);
        if (isRoomExists is not null)
        {
            return Result<string>.Failure("Oda ismi zaten mevcut");
        }

        mapper.Map(request, room);
        room.UpdatedAt = DateTime.Now;
        room.UpdatedBy = "Admin";

        roomRepository.Update(room);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Oda güncellemesi başarılı.");
    }
}
