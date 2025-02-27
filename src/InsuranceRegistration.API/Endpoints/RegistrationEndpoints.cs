using InsuranceRegistration.API.Requests;
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
        });
    }
}
