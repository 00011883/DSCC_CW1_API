#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["GamesStore_11883_API.csproj", "GamesStore_11883_API/"]
RUN dotnet restore "GamesStore_11883_API/GamesStore_11883_API.csproj"
WORKDIR "/src/GamesStore_11883_API"
COPY . .
RUN dotnet build "GamesStore_11883_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GamesStore_11883_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GamesStore_11883_API.dll"]