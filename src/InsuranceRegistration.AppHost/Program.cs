var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql")
                 .WithLifetime(ContainerLifetime.Persistent)
                 .WithEndpoint(1433, 1433, name: "ssms")
                 .WithDataVolume();

var db = sql.AddDatabase("InsuranceRegistrationDb");

builder.AddProject<Projects.InsuranceRegistration_API>("insuranceregistration-api")
    .WithReference(db)
    .WaitFor(db);

builder.Build().Run();