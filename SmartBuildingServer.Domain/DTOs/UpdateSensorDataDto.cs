namespace SmartBuildingServer.Domain.DTOs;
public sealed record UpdateSensorDataDto(
    int PinNumber,
    double Value,
    string? Value2);
