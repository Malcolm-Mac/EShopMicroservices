FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

COPY aspnetcore.pfx /https/aspnetcore.pfx

RUN chown -R app /https
RUN chmod -R 644 /https/aspnetcore.pfx

ENV ASPNETCORE_URLS="http://+:8080;https://+:8081"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetcore.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="malcolm123"

RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/Services/Ordering/Ordering.API/Ordering.API.csproj", "src/Services/Ordering/Ordering.API/"]
COPY ["src/BuildingBlocks/BuildingBlocks.csproj", "src/BuildingBlocks/"]
RUN dotnet restore "src/Services/Ordering/Ordering.API/Ordering.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Ordering/Ordering.API"
RUN dotnet build "Ordering.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Ordering.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ordering.API.dll"]
