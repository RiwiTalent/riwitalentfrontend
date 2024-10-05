# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src
COPY . .
RUN dotnet restore "RTFrontend.csproj"
RUN dotnet publish "RTFrontend.csproj" -c Release -o /app/publish

# Etapa de ejecución con Nginx
FROM nginx:alpine
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
