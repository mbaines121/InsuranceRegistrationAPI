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
        app.MapPost("/register-policy-holder", async (RegisterPolicyHolderRequest request, IPolicyHolderService policyHolderService) => {
            await policyHolderService.RegisterPolicyHolderAsync(request.FirstName, request.Surname, request.PolicyReferenceNumber, request.Email, request.Dob);
            
            return TypedResults.Ok();
        })
        .WithName("RegisterPolicyHolder")
        .WithDescription("Registers a customer (policy holder) with the AFI customer portal.")
        .Produces<RegisterPolicyHolderResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
