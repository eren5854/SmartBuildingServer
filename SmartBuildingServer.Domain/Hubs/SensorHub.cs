using Microsoft.AspNetCore.SignalR;
using SmartBuildingServer.Domain.Sensors;
using System.Security.Claims;

namespace SmartBuildingServer.Infrastructure.Hubs;
public sealed class SensorHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public async Task SendSensorData(SensorData sensorData)
    {
        var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (Guid.TryParse(userId, out var parsedUserId) && sensorData.Device!.Room!.AppUserId == parsedUserId)
        {
            await Clients.User(userId).SendAsync("ReceiveSensorData", sensorData);
        }
    }

    public override async Task OnConnectedAsync()
    {
        var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId != null)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userId);
        }
        await base.OnConnectedAsync();
    }
}
