# steeltoe.data.showcase

Example project to use Steel Toe Data Services.


# Running Application

Set connection string environment environment

```shell
export ConnectionString="Host=127.0.0.1;Database=postgres;Username=postgres;Password=$POSTGRES_DB_PASSWORD"
```

## Testing with Swagger


```shell
open http://localhost:5000/swagger/index.html
```

# Set up Migration

This application creates the needed database schema on startup.


Install DB migration

```shell
dotnet tool install --global dotnet-ef --version "7.*"
```

Create a migration

```shell
dotnet ef migrations add InitialCreate
```

View migration SQL script

```shell
dotnet ef migrations script
```

# Testing


```shell
dotnet  test
```
