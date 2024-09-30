# Comptroller.API
A REST API demo for the Comptroller of Public Accounts could simulate functionalities that a public finance or taxation-related system might use. This could involve managing financial data like tax filings, revenue reports, expenditures, or budgets.

## Use Case 
The Comptroller of Public Accounts needs an API to manage tax reports for businesses. This API will allow businesses to:
* Submit tax reports
* Retrieve tax report status
* Update or delete tax reports
* View annual revenue summary

The API will be built around a simple tax report submission system where businesses submit their tax reports, and the Comptroller can view, approve, or reject them.

## Steps to Build the API
1. Data Model: Create entities like Business and TaxReport.
2. Endpoints:
    - GET /api/taxreports: Retrieve a list of all submitted tax reports.
    - GET /api/taxreports/{id}: Retrieve details of a specific tax report.
    - POST /api/taxreports: Submit a new tax report.
    - PUT /api/taxreports/{id}: Update a submitted tax report.
    - DELETE /api/taxreports/{id}: Delete a tax report.
    - GET /api/revenue/{year}: Get annual revenue summary for the comptroller.
3. Using SQLite as a persistent database with Entity Framework Core
    - Setting up EF Core with SQLite.
    - Using dependency injection to persist the database context across requests.
    - Using migrations to generate and update the database schema.
4. Using Microsoft.AspNetCore.Authentication.JwtBearer and Microsoft.AspNetCore.Identity for login and register. 

## Steps to Deploy
1. Create a Linux App Service Plan 
```
az login
az group create --name ComptrollerApiResourceGroup --location westus
az appservice plan create --name ComptrollerApiServicePlan --resource-group ComptrollerApiResourceGroup --sku B1 --is-linux
az webapp create --name ComptrollerApi --resource-group ComptrollerApiResourceGroup --plan ComptrollerApiServicePlan --runtime "DOTNETCORE|8.0"
```
2. Publish Your Application 
    - `dotnet publish --configuration Release`
3. Deploy the Application to Azure 
    - Zip the published output:
    ```
    cd bin/Release/net8.0/publish
    zip -r deployment.zip .
    ```
    - Deploy the zip file: `az webapp deploy --resource-group ComptrollerApiResourceGroup --name ComptrollerApi --src-path deployment.zip --type zip`

## Testing 
### App Service Setting 
* Configuration: turn off "HTTPS only" 
* URL: http://comptrollerapi.azurewebsites.net/api/taxreports

## Issues 
* Not able to sign in through frontend React app, got 401 unauthorized error. 
