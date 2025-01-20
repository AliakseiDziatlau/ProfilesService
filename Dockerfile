FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY ProfilesService/ProfilesService.csproj .
RUN dotnet restore

COPY ProfilesService/ ./
RUN dotnet build -c Release -o /app/build

RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "ProfilesService.dll"]