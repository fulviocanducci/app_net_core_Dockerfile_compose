FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copiar csproj e restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Build da aplicacao
COPY . ./
RUN dotnet publish -c Release -o out

# Build da imagem
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "app-net-docker.dll"]