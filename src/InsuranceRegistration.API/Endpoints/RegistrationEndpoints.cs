using InsuranceRegistration.API.Requests;
using InsuranceRegistration.API.Responses;
using InsuranceRegistration.Services;

namespace InsuranceRegistration.API.Endpoints;

public class RegistrationEndpoints : CarterModule
{
    public RegistrationEndpoints() : base("/api")
    {
        WithTags("Customer Registration Endpoints");
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/policy-holder", async (
            RegisterPolicyHolderRequest request, 
            IPolicyHolderService policyHolderService, 
            IValidator<RegisterPolicyHolderRequest> validator) =>
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return TypedResults.ValidationProblem(validationResult.ToDictionary());
            }

            var result = await policyHolderService.RegisterPolicyHolderAsync(request.FirstName, request.Surname, request.PolicyReferenceNumber, request.Email, request.Dob);

            return Results.Ok(new RegisterPolicyHolderResponse
            {
                PolicyHolderId = result
            });
        })
        .WithName("Register Policy Holder")
        .WithDescription("Registers a customer (policy holder) with the AFI customer portal.")
        .Produces<RegisterPolicyHolderResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
