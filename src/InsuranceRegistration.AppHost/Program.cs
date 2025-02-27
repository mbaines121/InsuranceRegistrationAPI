var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.InsuranceRegistration_API>("insuranceregistration-api");

builder.Build().Run();
