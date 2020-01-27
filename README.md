# WebScraping
Um projeto para baixar os dados históricos da taxa selic

### Pacotes
- Microsoft.EntityFrameworkCore.SqlServer: https://docs.microsoft.com/pt-br/ef/core/get-started/install/

### Scaffolding
    dotnet aspnet-codegenerator controller -name TaxaSelicController -m TaxaSelic -dc WebScrapingContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
    
#### Tutorial: https://docs.microsoft.com/pt-br/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-3.1&tabs=visual-studio-code

#### Fonte de dados: https://www.bcb.gov.br/controleinflacao/historicotaxasjuros