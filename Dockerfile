#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CancelApi/CancelApi.csproj", "CancelApi/"]
RUN dotnet restore "CancelApi/CancelApi.csproj"
COPY . .
WORKDIR "/src/CancelApi"
RUN dotnet build "CancelApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CancelApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CancelApi.dll"]