#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Backend/Domain/Store/Dario.Robles.Store.Service/Dario.Robles.Store.Service.csproj", "Backend/Domain/Store/Dario.Robles.Store.Service/"]
RUN dotnet restore "./Backend/Domain/Store/Dario.Robles.Store.Service/Dario.Robles.Store.Service.csproj"
COPY . .
WORKDIR "/src/Backend/Domain/Store/Dario.Robles.Store.Service"
RUN dotnet build "./Dario.Robles.Store.Service.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Dario.Robles.Store.Service.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dario.Robles.Store.Service.dll"]