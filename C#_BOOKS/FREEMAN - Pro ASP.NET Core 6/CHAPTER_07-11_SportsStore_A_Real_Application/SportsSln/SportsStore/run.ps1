dotnet publish -c Release
docker-compose build
docker-compose up sqlserver -d
docker-compose up sportsstore -d