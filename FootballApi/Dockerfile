FROM mcr.microsoft.com/dotnet/nightly/sdk:10.0-preview

WORKDIR /app

COPY . .

RUN dotnet restore FootballApi.sln
RUN dotnet build --no-restore -c Release FootballApi.sln
RUN dotnet publish --no-build -c Release -o out FootballApi.sln

EXPOSE 80
ENTRYPOINT ["dotnet", "out/Api.dll"]
