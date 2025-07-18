FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8081

RUN mkdir -p ./data-protection-keys

COPY aspnetcore.pfx /https/aspnetcore.pfx

RUN chown -R app /https
RUN chmod -R 644 /https/aspnetcore.pfx
RUN chmod -R 644 ./data-protection-keys

ENV ASPNETCORE_URLS="https://+:8081;http://+:8080;"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetcore.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="malcolm123"

RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/WebApps/Shopping.Web/Shopping.Web.csproj", "src/WebApps/Shopping.Web/"]
RUN dotnet restore "src/WebApps/Shopping.Web/Shopping.Web.csproj"
COPY . .
WORKDIR "/src/src/WebApps/Shopping.Web"
RUN dotnet build "Shopping.Web.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Shopping.Web.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shopping.Web.dll"]
