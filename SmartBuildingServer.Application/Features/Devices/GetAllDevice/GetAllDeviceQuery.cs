using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Application.Features.Devices.GetAllDevice;
public sealed record GetAllDeviceQuery(): IRequest<Result<List<Device>>>;
