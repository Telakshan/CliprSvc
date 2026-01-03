FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["src/API/Clipr.Api/Clipr.Api.csproj", "src/API/Clipr.Api/"]
COPY ["src/Modules/Upload/Clipr.Modules.Upload.Application/Clipr.Modules.Upload.Application.csproj", "src/Modules/Upload/Clipr.Modules.Upload.Application/"]
COPY ["src/Modules/Upload/Clipr.Modules.Upload.Domain/Clipr.Modules.Upload.Domain.csproj", "src/Modules/Upload/Clipr.Modules.Upload.Domain/"]
COPY ["src/Modules/Upload/Clipr.Modules.Upload.Infrastructure/Clipr.Modules.Upload.Infrastructure.csproj", "src/Modules/Upload/Clipr.Modules.Upload.Infrastructure/"]
COPY ["src/Modules/Upload/Clipr.Modules.Upload.Presentation/Clipr.Modules.Upload.Presentation.csproj", "src/Modules/Upload/Clipr.Modules.Upload.Presentation/"]
RUN dotnet restore "./src/API/Clipr.Api/Clipr.Api.csproj"
COPY . .
WORKDIR "/src/src/API/Clipr.Api"
RUN dotnet build "./Clipr.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Clipr.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Clipr.Api.dll"]
