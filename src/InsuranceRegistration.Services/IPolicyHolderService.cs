namespace InsuranceRegistration.Services;

public interface IPolicyHolderService
{
    Task<int> RegisterPolicyHolderAsync(string firstname, string surname, string policyNumber, string? email, DateTime? dob);
}
