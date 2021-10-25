
FROM node AS node_base
WORKDIR /app

COPY "src/mb.srs.Web/package.json" .
COPY "src/mb.srs.Web/package-lock.json" .
COPY "src/mb.srs.Web/webpack.config.js" .
COPY "src/mb.srs.Web/assets/" assets/
ENV NODE_ENV=production
RUN npm ci
RUN npx webpack-cli bundle --mode "production"
RUN npx webpack-cli bundle --mode "development"


FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /app

COPY "src/mb.srs.Web/mb.srs.Web.csproj" "mb.srs.Web/"
COPY "src/mb.srs.Core/mb.srs.Core.csproj" "mb.srs.Core/"
COPY "src/mb.srs.Infrastructure/mb.srs.Infrastructure.csproj" "mb.srs.Infrastructure/"
COPY "src/mb.srs.SharedKernel/mb.srs.SharedKernel.csproj" "mb.srs.SharedKernel/"
RUN dotnet restore "mb.srs.Web/mb.srs.Web.csproj"
COPY src .

WORKDIR /app/mb.srs.Web
RUN dotnet publish "mb.srs.Web.csproj" -c Release -o /app/build --no-restore

COPY --from=node_base /app/wwwroot /app/build/wwwroot


FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS fainal
WORKDIR /app
EXPOSE 80
EXPOSE 443
WORKDIR /app
COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "mb.srs.Web.dll"]