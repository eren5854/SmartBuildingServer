FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

RUN mkdir -p /app/wwwroot && chmod -R 777 /app/wwwroot

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SmartBuildingServer.WebAPI/SmartBuildingServer.WebAPI.csproj", "SmartBuildingServer.WebAPI/"]
COPY ["SmartBuildingServer.Application/SmartBuildingServer.Application.csproj", "SmartBuildingServer.Application/"]
COPY ["SmartBuildingServer.Domain/SmartBuildingServer.Domain.csproj", "SmartBuildingServer.Domain/"]
COPY ["SmartBuildingServer.Infrastructure/SmartBuildingServer.Infrastructure.csproj", "SmartBuildingServer.Infrastructure/"]
RUN dotnet restore "./SmartBuildingServer.WebAPI/SmartBuildingServer.WebAPI.csproj"
COPY . .
WORKDIR "/src/SmartBuildingServer.WebAPI"
RUN dotnet build "./SmartBuildingServer.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SmartBuildingServer.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN mkdir -p /app/wwwroot && chmod -R 777 /app/wwwroot

ENTRYPOINT ["dotnet", "SmartBuildingServer.WebAPI.dll"]