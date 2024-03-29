#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Test.WebApi/Test.WebApi.csproj", "Test.WebApi/"]
COPY ["Test.Application/Test.Application.csproj", "Test.Application/"]
COPY ["Test.Domain/Test.Domain.csproj", "Test.Domain/"]
COPY ["Task.Infrastructure/Task.Infrastructure.csproj", "Task.Infrastructure/"]
RUN dotnet restore "Test.WebApi/Test.WebApi.csproj"
COPY . .
WORKDIR "/src/Test.WebApi"
RUN dotnet build "Test.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Test.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Test.WebApi.dll"]