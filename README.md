Installation
```
git clone https://github.com/daniel-statsig/dotnet-asp-example
cd dotnet-asp-example

dotnet restore
dotnet build
dotnet run --project WebApplication1
```


Testing
```
curl 'http://localhost:5155/test' \
--header 'Content-Type: application/json' \
--data-raw '"prod@email.com"'
```
