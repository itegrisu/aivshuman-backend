# Adım 1: Projeyi build etmek için .NET SDK'sını kullan
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Tüm proje dosyalarını kopyala
COPY . .
# Gerekli kütüphaneleri yükle
RUN dotnet restore "./HumanVSAi.Api/HumanVSAi.Api.csproj"

# Projeyi yayınla (publish et)
WORKDIR "/source/HumanVSAi.Api"
RUN dotnet publish "HumanVSAi.Api.csproj" -c Release -o /app/publish

# Adım 2: Yayınlanmış uygulamayı çalıştırmak için daha hafif bir imaj kullan
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "HumanVSAi.Api.dll"]