#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["LanguagesCourse.Api/LanguagesCourse.Api.csproj", "LanguagesCourse.Api/"]
RUN dotnet restore "LanguagesCourse.Api/LanguagesCourse.Api.csproj"
COPY . .
WORKDIR "/src/LanguagesCourse.Api"
RUN dotnet build "LanguagesCourse.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LanguagesCourse.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LanguagesCourse.Api.dll"]