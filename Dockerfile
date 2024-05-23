FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY *.sln .
COPY Api ./Api
COPY ApiLibrary ./ApiLibrary
COPY BaseLibrary ./BaseLibrary

RUN dotnet restore Api/Api.csproj
COPY . .

RUN dotnet build Api/Api.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish Api/Api.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]