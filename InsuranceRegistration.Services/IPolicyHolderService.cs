namespace InsuranceRegistration.Services;

public interface IPolicyHolderService
{
    public Task RegisterPolicyHolderAsync(string firstname, string surname, string policyNumber, string email, DateTime? dob);
}
