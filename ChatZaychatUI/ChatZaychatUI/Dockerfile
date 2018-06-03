FROM microsoft/aspnetcore:2.0-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 51460
EXPOSE 44355

FROM microsoft/aspnetcore-build:2.0-nanoserver-sac2016 AS build
WORKDIR /src
COPY ChatZaychatUI/ChatZaychatUI.csproj ChatZaychatUI/
RUN dotnet restore ChatZaychatUI/ChatZaychatUI.csproj
COPY . .
WORKDIR /src/ChatZaychatUI
RUN dotnet build ChatZaychatUI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ChatZaychatUI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ChatZaychatUI.dll"]
