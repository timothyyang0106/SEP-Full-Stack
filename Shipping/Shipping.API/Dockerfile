FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Shipping.API/Shipping.API.csproj", "Shipping.API/"]
COPY ["ApplicationCore/ApplicationCore.csproj", "ApplicationCore/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "Shipping.API/Shipping.API.csproj"
COPY . .
WORKDIR "/src/Shipping.API"
RUN dotnet build "Shipping.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shipping.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shipping.API.dll"]
