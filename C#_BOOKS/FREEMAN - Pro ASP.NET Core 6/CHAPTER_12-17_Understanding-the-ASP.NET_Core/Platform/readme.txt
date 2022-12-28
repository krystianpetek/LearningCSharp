sqlcmd -S "(localdb)\MSSQLLocalDB"
CREATE DATABASE CacheDb
GO

dotnet tool install --global dotnet-sql-cache
dotnet sql-cache create "Server=(localdb)\MSSQLLocalDB;Database=CacheDb" dbo DataCache

TO SEED CalcDB use first
dotnet run INITDB=true