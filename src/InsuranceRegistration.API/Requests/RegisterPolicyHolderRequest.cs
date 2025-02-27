namespace InsuranceRegistration.API.Requests;

public class RegisterPolicyHolderRequest
{
    public string FirstName { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string PolicyReferenceNumber { get; set; } = default!;
    public string? Email { get; set; }
    public DateTime? Dob { get; set; }
}
