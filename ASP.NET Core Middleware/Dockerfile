#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ASP.NET Core Middleware/ASP.NET Core Middleware.csproj", "ASP.NET Core Middleware/"]
RUN dotnet restore "ASP.NET Core Middleware/ASP.NET Core Middleware.csproj"
COPY . .
WORKDIR "/src/ASP.NET Core Middleware"
RUN dotnet build "ASP.NET Core Middleware.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ASP.NET Core Middleware.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ASP.NET Core Middleware.dll"]