# Insurance Registration API

Insurance Registration API is the Animal Friends Insurance tech test submission for Mark Baines.

The project is built in .NET 9 Minimal API, with an Aspire web host and a SQL Server database.

## Getting Started

You can get started quickly by opening in VS 2022, setting the startup project as InsuranceRegistration.AppHost and pressing F5. The Aspire web host will create and run containers for SQL Server, the database and API.

You'll need to have Docker Desktop running for the Aspire host to be able to create the containers.

The Swagger endpoint can be accessed via:

[https://localhost:7192/](https://localhost:7192/)

The customer (policy holder) data can be submitted via:

[https://localhost:7192/api/policy-holder](https://localhost:7192/api/policy-holder)

If there's any issues with getting up and running I'd be happy to take a look.

## Accessing the DB

The database can be accessed with Azure Data Studio. The connection string can be obtained from the Aspire Dashboard under the `insuranceregistration-api`.

If there is an issue logging in as 'SA', you may need to make sure that any local instances of SQL Server have been stopped first.

## Design Decisions

I called the URI and model 'policy holder' instead of 'customer', as it seems likely that there will also be other customer types and wanted to be more deliberate about what type of customer we are working with in this application.

I used Aspire so that the SQL Server database could easily be included and set up with the API with no external configuration or setup required.

The project architecture was kept "as simple as possible, but no simpler". It's a basic 'N-tier' style - I considered keeping the service and infrastructure in the API project in a 'vertical slice' architecture but I decided to split it out in the end.

If it were to grow significantly then the N-tier approach would probably be easier to refactor.

## Next Steps

The following areas could be improved but were kept simple in this case due to time constraints:

* Improve `PolicyHolderService` with exception handling and/or a complex return object.
* The POST API endpoint needs integration tests.
* Improve global exception handling. Currently we use ProblemDetails to catch global errors and return a ProblemDetail type response.



