using InsuranceRegistration.API.Data;
using InsuranceRegistration.Infrastructure.Models;

namespace InsuranceRegistration.Services;


/// <summary>
/// Saves a policy holder record to the database.
/// With more time, this should handle exceptions, return success status and be integration tested.
/// </summary>
/// <param name="_context"></param>
public class PolicyHolderService(ApplicationDbContext _context) : IPolicyHolderService
{
    public async Task<int> RegisterPolicyHolderAsync(string firstname, string surname, string policyNumber, string? email, DateTime? dob)
    {
        var policyHolder = new PolicyHolder
        {
            FirstName = firstname,
            Surname = surname,
            PolicyReferenceNumber = policyNumber,
            Email = email,
            Dob = dob
        };

        await _context.PolicyHolders.AddAsync(policyHolder);

        await _context.SaveChangesAsync();

        return policyHolder.Id;
    }
}
