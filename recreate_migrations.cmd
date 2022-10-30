dotnet ef migrations remove --force
dotnet ef migrations add InitialCreate --output-dir Data/Migrations
dotnet ef database update
