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
3. using SQLite as a persistent database with Entity Framework Core
    - Setting up EF Core with SQLite.
    - Using dependency injection to persist the database context across requests.
    - Using migrations to generate and update the database schema.