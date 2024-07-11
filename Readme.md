# Postgres Hello World for dotnet core 8

This is a database first approach. The docker command below will spin up a postgres server but you will need to initialize the db by connecting to it using Azure Data studio and running the provided init.sql script. As you make changes you can Scaffold the models in /Models with the following command in the Nuget Command Prompt. Or in Rider under Tools / Entity Framework / Scaffold Database

`ef dbcontext scaffold --project PostgresHelloWorldApi/PostgresHelloWorldApi.csproj --startup-project PostgresHelloWorldApi/PostgresHelloWorldApi.csproj --configuration Debug Host=localhost;Port=5432;Database=TodoDB;Username=pguser;Password=password Npgsql.EntityFrameworkCore.PostgreSQL --data-annotations --context MyDbContext --context-dir Context --force --output-dir Models`


`cd PostgresHelloWorldApi`


`dotnet build .`


`docker run --name TodoDb -e POSTGRES_DB=TodoDB  -e POSTGRES_USER=pguser -e POSTGRES_PASSWORD=password -p 5432:5432 -v pgdata:/var/lib/postgresql/data -d postgres`


`dotnet run .`

Testing with fork.