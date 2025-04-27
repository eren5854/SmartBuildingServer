using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Rooms;

namespace SmartBuildingServer.Application.Features.Rooms.CreateRoom;
internal sealed class CreateRoomCommandHandler(
    IRoomRepository roomRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateRoomCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var isRoomExists = roomRepository.GetByExpression(g => g.RoomName == request.RoomName && g.AppUserId == request.AppUserId);
        if(isRoomExists is not null)
        {
            return Result<string>.Failure("Room name already exists");
        }

        Room room = mapper.Map<Room>(request);
        room.CreatedAt = DateTime.UtcNow;
        room.CreatedBy = "Admin";

        await roomRepository.AddAsync(room, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Oda kaydı başarılı.");
    }
}
