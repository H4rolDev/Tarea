# Usa una imagen base de ASP.NET Core 6.0
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Usa una imagen para el SDK de .NET 6.0 para compilar el proyecto
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copia los archivos de proyecto
COPY ["Main/Main.csproj", "Main/"]
COPY ["DataBase/DataBase.csproj", "DataBase/"]

# Restaurar dependencias de NuGet
RUN dotnet restore "Main/Main.csproj"
RUN dotnet restore "DataBase/DataBase.csproj"

# Copiar todo el código fuente al contenedor
COPY . .

# Compilar y publicar el proyecto
RUN dotnet publish "Main/Main.csproj" -c Release -o /app

# Crear la imagen final desde la imagen base
FROM base AS final
WORKDIR /app
COPY --from=build /app .

# Especificar el archivo DLL de entrada
ENTRYPOINT ["dotnet", "Main.dll"]
