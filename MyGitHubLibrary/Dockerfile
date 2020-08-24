#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MyGitHubLibrary/MyGitHubLibrary.csproj", "MyGitHubLibrary/"]
RUN dotnet restore "MyGitHubLibrary/MyGitHubLibrary.csproj"
COPY . .
WORKDIR "/src/MyGitHubLibrary"
RUN dotnet build "MyGitHubLibrary.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyGitHubLibrary.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyGitHubLibrary.dll"]
