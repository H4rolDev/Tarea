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
RUN dotnet restore "Main/Main.csproj"

# Copiar el resto del código fuente y compilar
COPY . .
WORKDIR "/src/Main"
RUN dotnet build "Main.csproj" -c Release -o /app/build

# Publicar el proyecto
RUN dotnet publish "Main.csproj" -c Release -o /app/publish

# Configurar el contenedor final para ejecutar la aplicación
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Especificar el archivo DLL de entrada
ENTRYPOINT ["dotnet", "Main.dll"]
