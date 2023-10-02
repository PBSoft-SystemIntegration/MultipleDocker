#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DockerService/DockerService.csproj", "DockerService/"]
RUN dotnet restore "DockerService/DockerService.csproj"
COPY . .
WORKDIR "/src/DockerService"
RUN dotnet build "DockerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DockerService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerService.dll"]