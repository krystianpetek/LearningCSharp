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

dotnet new classlib -o DataModel
dotnet add DataModel package System.ComponentModel.Annotations
Move-Item -Path @("Models/Person.cs", "Models/Location.cs", "Models/Department.cs") ../DataModel
dotnet sln ..\Advanced-WebApp.sln add ..\DataModel
dotnet add reference ../DataModel

dotnet new blazorwasm -o .\BlazorWebAssembly
dotnet add .\BlazorWebAssembly reference .\DataModel
cd .\Advanced
dotnet add reference ..\DataModel ..\BlazorWebAssembly
dotnet sln add ./DataModel ./BlazorWebAssembly
dotnet add package Microsoft.AspNetCore.Components.WebAssembly.Server

dotnet ef migrations add --context IdentityContext Initial
dotnet ef database update --context IdentityContext
dotnet ef database drop --force --context IdentityContext