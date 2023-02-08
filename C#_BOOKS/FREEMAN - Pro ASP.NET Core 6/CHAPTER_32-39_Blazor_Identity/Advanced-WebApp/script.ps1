dotnet new globaljson --sdk-version 7.0.0 --roll-forward "latestFeature" --force
dotnet new web --output Advanced --framework net7.0
dotnet sln .\Advanced-WebApp.sln add .\Advanced\
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef

dotnet ef migrations add Initial
dotnet ef database update