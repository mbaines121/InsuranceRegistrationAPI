using InsuranceRegistration.API.Data;
using InsuranceRegistration.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.AddSqlServerDbContext<ApplicationDbContext>(connectionName: "InsuranceRegistrationDb");

builder.Services
    .AddServices();

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        // We're making sure the database is clean each time the app is executed in this tech test just for ease of use.
        await context.Database.EnsureDeletedAsync();
        await context.Database.MigrateAsync();
    }
}

app.UseHttpsRedirection();

app.Run();