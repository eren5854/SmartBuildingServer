using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartBuildingServer.Application.Features.Rooms.CreateRoom;
using SmartBuildingServer.Application.Features.Rooms.DeleteRoom;
using SmartBuildingServer.Application.Features.Rooms.GetAllRoom;
using SmartBuildingServer.Application.Features.Rooms.GetAllRoomByAppUserId;
using SmartBuildingServer.Application.Features.Rooms.GetRoom;
using SmartBuildingServer.Application.Features.Rooms.UpdateRoom;
using SmartBuildingServer.WebAPI.Abstractions;

namespace SmartBuildingServer.WebAPI.Controllers;

public sealed class RoomsController : ApiController
{
    public RoomsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllRoomQuery(), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllByAppUserId(Guid appUserId, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllRoomByAppUserIdQuery(appUserId), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> Get(Guid Id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetRoomCommand(Id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid Id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteRoomCommand(Id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
