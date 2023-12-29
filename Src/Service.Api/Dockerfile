#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["Src/Service.Api/Service.Api.csproj", "Src/Service.Api/"]
COPY ["Src/Application/Application.csproj", "Src/Application/"]
COPY ["Src/Domain/Domain.csproj", "Src/Domain/"]
COPY ["Src/Contract/Contract.csproj", "Src/Contract/"]
COPY ["Src/Infrastructure/Infrastructure.csproj", "Src/Infrastructure/"]
RUN dotnet restore "Src/Service.Api/Service.Api.csproj"
COPY . .
WORKDIR "/src/Src/Service.Api"
RUN dotnet build "Service.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Service.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Service.Api.dll"]