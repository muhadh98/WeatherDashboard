# ---------- Build Stage ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .csproj file and restore dependencies
COPY WeatherDashboard/WeatherDashboard.csproj WeatherDashboard/
RUN dotnet restore WeatherDashboard/WeatherDashboard.csproj

# Copy everything else
COPY WeatherDashboard/ WeatherDashboard/

# Build and publish the app
WORKDIR /src/WeatherDashboard
RUN dotnet publish -c Release -o /app/publish

# ---------- Runtime Stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "WeatherDashboard.dll"]