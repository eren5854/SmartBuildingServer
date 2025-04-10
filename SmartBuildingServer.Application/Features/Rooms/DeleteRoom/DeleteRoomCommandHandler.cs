using ED.GenericRepository;
using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Rooms;

namespace SmartBuildingServer.Application.Features.Rooms.DeleteRoom;
internal sealed class DeleteRoomCommandHandler(
    IRoomRepository roomRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteRoomCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
        Room room = await roomRepository.GetByExpressionAsync(g => g.Id == request.Id, cancellationToken);
        if (room is null)
        {
            return Result<string>.Failure("Room not found");
        }

        room.IsDeleted = true;

        roomRepository.Update(room);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Oda silme işlemi başarılı");
    }
}
