#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TraineeTracker.MVC/TraineeTracker.MVC.csproj", "TraineeTracker.MVC/"]
COPY ["TraineeTracker.Indentity/TraineeTracker.Indentity.csproj", "TraineeTracker.Indentity/"]
COPY ["TraineeTracker.Application/TraineeTracker.Application.csproj", "TraineeTracker.Application/"]
COPY ["TraineeTracker.Domain/TraineeTracker.Domain.csproj", "TraineeTracker.Domain/"]
RUN dotnet restore "TraineeTracker.MVC/TraineeTracker.MVC.csproj"
COPY . .
WORKDIR "/src/TraineeTracker.MVC"
RUN dotnet build "TraineeTracker.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TraineeTracker.MVC.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TraineeTracker.MVC.dll"]