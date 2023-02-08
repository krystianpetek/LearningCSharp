dotnet new globaljson --sdk-version 7.0.0 --roll-forward "latestFeature" --force
dotnet new web --output Advanced --framework net7.0
dotnet sln .\Advanced-WebApp.sln add .\Advanced\
