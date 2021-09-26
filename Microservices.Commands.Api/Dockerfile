#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Microservices.Commands.Api/Microservices.Commands.Api.csproj", "Microservices.Commands.Api/"]
RUN dotnet restore "Microservices.Commands.Api/Microservices.Commands.Api.csproj"
COPY . .
WORKDIR "/src/Microservices.Commands.Api"
RUN dotnet build "Microservices.Commands.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservices.Commands.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservices.Commands.Api.dll"]