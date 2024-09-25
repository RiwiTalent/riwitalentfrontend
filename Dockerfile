# Etapa de compilación (opcional, si necesitas realizar cambios en el código)
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src
COPY . .
RUN dotnet restore "riwi.csproj"
RUN dotnet publish "riwi.csproj" -c Release -o /app/publish

# Etapa de ejecución
FROM nginx:alpine
WORKDIR /usr/share/nginx/html
COPY --from=build /app/publish .

# Configuración de Nginx (opcional, puedes personalizar)
COPY nginx.conf /etc/nginx/nginx.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
