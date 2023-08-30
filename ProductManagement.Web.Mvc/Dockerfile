FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
RUN ln -s ~/.dotnet/tools/libman /usr/local/bin/libman

WORKDIR /src
COPY ["src/ProductManagement.Web.Mvc/ProductManagement.Web.Mvc.csproj", "src/ProductManagement.Web.Mvc/"]
COPY ["src/ProductManagement.Web.Core/ProductManagement.Web.Core.csproj", "src/ProductManagement.Web.Core/"]
COPY ["src/ProductManagement.Application/ProductManagement.Application.csproj", "src/ProductManagement.Application/"]
COPY ["src/ProductManagement.Core/ProductManagement.Core.csproj", "src/ProductManagement.Core/"]
COPY ["src/ProductManagement.EntityFrameworkCore/ProductManagement.EntityFrameworkCore.csproj", "src/ProductManagement.EntityFrameworkCore/"]
WORKDIR "/src/src/ProductManagement.Web.Mvc"
RUN dotnet restore 

WORKDIR /src
COPY ["src/ProductManagement.Web.Mvc", "src/ProductManagement.Web.Mvc"]
COPY ["src/ProductManagement.Web.Core", "src/ProductManagement.Web.Core"]
COPY ["src/ProductManagement.Application", "src/ProductManagement.Application"]
COPY ["src/ProductManagement.Core", "src/ProductManagement.Core"]
COPY ["src/ProductManagement.EntityFrameworkCore", "src/ProductManagement.EntityFrameworkCore"]
WORKDIR "/src/src/ProductManagement.Web.Mvc"
RUN libman restore
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "ProductManagement.Web.Mvc.dll"]
