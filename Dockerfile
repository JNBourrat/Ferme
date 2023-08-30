# Utilisez l'image de base .NET 6.0
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS lfdpa-base
WORKDIR /app
EXPOSE 80

RUN dotnet tool install -g dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

WORKDIR /app
COPY . .
