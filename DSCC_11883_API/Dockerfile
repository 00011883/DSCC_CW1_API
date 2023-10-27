#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DSCC_11883_API/DSCC_11883_API.csproj", "DSCC_11883_API/"]
RUN dotnet restore "DSCC_11883_API/DSCC_11883_API.csproj"
COPY . .
WORKDIR "/src/DSCC_11883_API"
RUN dotnet build "DSCC_11883_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DSCC_11883_API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DSCC_11883_API.dll"]