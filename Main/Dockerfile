# Usar una imagen base de ASP.NET Core 6.0 para el entorno de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Imagen del SDK de .NET 6.0 para compilar y restaurar dependencias
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copiar los archivos de proyecto y restaurar dependencias de NuGet
COPY ["Main/Main.csproj", "Main/"]
COPY ["DataBase/DataBase.csproj", "DataBase/"]
RUN dotnet restore "Main/Main.csproj"

# Limpiar el caché de NuGet para evitar problemas de corrupción
RUN dotnet nuget locals all --clear

# Copiar el resto del código fuente
COPY . .

# Compilar el proyecto
WORKDIR "/src/Main"
RUN dotnet build "Main.csproj" -c Release -o /app/build

# Publicar el proyecto (sin --no-restore)
RUN dotnet publish "Main.csproj" -c Release -o /app/publish

# Configurar el contenedor final para ejecutar la aplicación
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Especificar el archivo DLL de entrada
ENTRYPOINT ["dotnet", "Main.dll"]
