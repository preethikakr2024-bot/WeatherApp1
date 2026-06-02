FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore WeatherApp.csproj --no-cache
RUN dotnet publish WeatherApp.csproj -c Release -o /app/publish

FROM nginx:alpine
# Copy the entire publish folder, not just wwwroot
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html
COPY nginx.conf /etc/nginx/nginx.conf
EXPOSE 80