
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Presentation/SmartPark.API.csproj", "Presentation/"]
COPY ["Domain/SmartPark.Domain.csproj", "Domain/"]
COPY ["Services/SmartPark.Services/SmartPark.Services.csproj", "Services/SmartPark.Services/"]
COPY ["Repositories/SmartPark.Repositories.Databases.MongoDb/SmartPark.Repositories.Databases.MongoDb.csproj", "Repositories/SmartPark.Repositories.Databases.MongoDb/"]
RUN dotnet restore "./Presentation/SmartPark.API.csproj"
COPY . .
WORKDIR "/src/Presentation"
RUN dotnet build "./SmartPark.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SmartPark.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartPark.API.dll"]