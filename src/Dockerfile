FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Gacha64Http.csproj", "./"]
RUN dotnet restore "Gacha64Http.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Gacha64Http.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gacha64Http.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gacha64Http.dll"]
