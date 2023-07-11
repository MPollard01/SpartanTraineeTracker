#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TraineeTracker.Api/TraineeTracker.Api.csproj", "TraineeTracker.Api/"]
COPY ["TraineeTracker.Application/TraineeTracker.Application.csproj", "TraineeTracker.Application/"]
COPY ["TraineeTracker.Domain/TraineeTracker.Domain.csproj", "TraineeTracker.Domain/"]
COPY ["TraineeTracker.Indentity/TraineeTracker.Indentity.csproj", "TraineeTracker.Indentity/"]
COPY ["TraineeTracker.Infrastructure/TraineeTracker.Infrastructure.csproj", "TraineeTracker.Infrastructure/"]
COPY ["TraineeTracker.Persistence/TraineeTracker.Persistence.csproj", "TraineeTracker.Persistence/"]
RUN dotnet restore "TraineeTracker.Api/TraineeTracker.Api.csproj"
COPY . .
WORKDIR "/src/TraineeTracker.Api"
RUN dotnet build "TraineeTracker.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TraineeTracker.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TraineeTracker.Api.dll"]