FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY VisualRiders.PointOfSale.Project/*.csproj .
RUN dotnet restore

COPY VisualRiders.PointOfSale.Project/. .
RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
COPY --from=build /src/pos.db ./
ENTRYPOINT ["dotnet", "VisualRiders.PointOfSale.Project.dll"]