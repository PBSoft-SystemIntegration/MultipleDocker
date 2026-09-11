FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
ENV ASPNETCORE_HTTP_PORTS=80
EXPOSE 80
USER $APP_UID

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY DockerService/DockerService.csproj DockerService/
RUN dotnet restore DockerService/DockerService.csproj
COPY DockerService/ DockerService/
RUN dotnet publish DockerService/DockerService.csproj -c Release -o /app/publish --no-restore /p:UseAppHost=false

FROM base AS final
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DockerService.dll"]
