FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore "Api/Api.csproj" --disable-parallel
RUN dotnet publish "Api/Api.csproj" -c Release -o out --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/out ./

EXPOSE 8080

ENTRYPOINT [ "dotnet", "Api.dll" ]