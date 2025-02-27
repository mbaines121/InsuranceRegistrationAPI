using InsuranceRegistration.API.Data;
using InsuranceRegistration.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.AddSqlServerDbContext<ApplicationDbContext>(connectionName: "InsuranceRegistrationDb");

builder.Services.AddServices();
builder.Services.AddCarter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddProblemDetails();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Insurance Registration API",
        Description = "The Insurance Registration API allows customers to register for the AFI customer portal.",
        Contact = new OpenApiContact
        {
            Name = "Mark Baines",
            Email = "markbaines121@protonmail.com"
        }
    });
});

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapCarter();

if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        // We're making sure the database is clean each time the app is executed in this tech test just for ease of use.
        await context.Database.EnsureDeletedAsync();
        await context.Database.MigrateAsync();
    }

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;

    });
}

app.UseHttpsRedirection();

app.Run();