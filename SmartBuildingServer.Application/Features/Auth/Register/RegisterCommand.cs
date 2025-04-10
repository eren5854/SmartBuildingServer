using ED.Result;
using MediatR;

namespace SmartBuildingServer.Application.Features.Auth.Register;
public sealed record RegisterCommand(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Password): IRequest<Result<string>>;
