FROM microsoft/aspnetcore:2.0-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-sac2016 AS build
WORKDIR /src
COPY ChatZaychatAPI/ChatZaychatAPI.csproj ChatZaychatAPI/
RUN dotnet restore ChatZaychatAPI/ChatZaychatAPI.csproj
COPY . .
WORKDIR /src/ChatZaychatAPI
RUN dotnet build ChatZaychatAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ChatZaychatAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ChatZaychatAPI.dll"]
