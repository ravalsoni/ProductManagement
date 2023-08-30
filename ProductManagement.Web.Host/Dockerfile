FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/ProductManagement.Web.Host/ProductManagement.Web.Host.csproj", "src/ProductManagement.Web.Host/"]
COPY ["src/ProductManagement.Web.Core/ProductManagement.Web.Core.csproj", "src/ProductManagement.Web.Core/"]
COPY ["src/ProductManagement.Application/ProductManagement.Application.csproj", "src/ProductManagement.Application/"]
COPY ["src/ProductManagement.Core/ProductManagement.Core.csproj", "src/ProductManagement.Core/"]
COPY ["src/ProductManagement.EntityFrameworkCore/ProductManagement.EntityFrameworkCore.csproj", "src/ProductManagement.EntityFrameworkCore/"]
WORKDIR "/src/src/ProductManagement.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/ProductManagement.Web.Host", "src/ProductManagement.Web.Host"]
COPY ["src/ProductManagement.Web.Core", "src/ProductManagement.Web.Core"]
COPY ["src/ProductManagement.Application", "src/ProductManagement.Application"]
COPY ["src/ProductManagement.Core", "src/ProductManagement.Core"]
COPY ["src/ProductManagement.EntityFrameworkCore", "src/ProductManagement.EntityFrameworkCore"]
WORKDIR "/src/src/ProductManagement.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "ProductManagement.Web.Host.dll"]
