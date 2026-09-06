#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["Car.API/SD.Car.API.csproj", "Car.API/"]
RUN dotnet restore "Car.API/SD.Car.API.csproj"
COPY . .
WORKDIR "/src/Car.API"
RUN dotnet build "SD.Car.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SD.Car.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SD.Car.API.dll"]