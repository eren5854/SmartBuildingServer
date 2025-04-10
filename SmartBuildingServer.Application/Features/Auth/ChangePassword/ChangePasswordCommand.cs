using ED.Result;
using MediatR;

namespace SmartBuildingServer.Application.Features.Auth.ChangePassword;
public sealed record ChangePasswordCommand(
    Guid AppUserId,
    string CurrentPassword,
    string NewPassword) : IRequest<Result<string>>;
