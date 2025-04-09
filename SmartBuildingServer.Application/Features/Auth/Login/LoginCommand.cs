using ED.Result;
using MediatR;

namespace SmartBuildingServer.Application.Features.Auth.Login;
public sealed record LoginCommand(
    string EmailOrUserName,
    string Password): IRequest<Result<LoginCommandResponse>>;
