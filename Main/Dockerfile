# Usa una imagen base de ASP.NET Core 6.0
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Usa una imagen para el SDK de .NET 6.0 para compilar el proyecto
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copia el archivo .csproj de la carpeta Main
COPY ["Main/Main.csproj", "./"]
RUN dotnet restore --no-cache

# Copia todos los archivos de Main al contenedor
COPY Main/. .

# Compila el proyecto y genera la publicación
RUN dotnet publish -c Release -o /app

# Crea la imagen final desde la imagen base
FROM base AS final
WORKDIR /app
COPY --from=build /app .

# Especifica el archivo DLL de tu aplicación
ENTRYPOINT ["dotnet", "Main.dll"]
