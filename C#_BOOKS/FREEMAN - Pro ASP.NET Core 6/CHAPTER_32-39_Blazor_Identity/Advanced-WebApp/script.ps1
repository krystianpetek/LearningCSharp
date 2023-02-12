dotnet new globaljson --sdk-version 7.0.0 --roll-forward "latestFeature" --force
dotnet new web --output Advanced --framework net7.0
dotnet sln .\Advanced-WebApp.sln add .\Advanced\
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef

dotnet ef migrations add Initial
dotnet ef database update

libman init -p cdnjs
libman install bootstrap -d wwwroot/lib/bootstrap

npm install --save-dev @types/blazor__javascript-interop
npm install --save-dev eslint
New-Item -Name ".eslintrc.js"