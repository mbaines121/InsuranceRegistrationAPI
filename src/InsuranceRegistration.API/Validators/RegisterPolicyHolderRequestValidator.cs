using InsuranceRegistration.API.Requests;

namespace InsuranceRegistration.API.Validators;

public class RegisterPolicyHolderRequestValidator : AbstractValidator<RegisterPolicyHolderRequest>
{
    public RegisterPolicyHolderRequestValidator()
    {
        RuleFor(m => m.FirstName)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50)
            .WithMessage("The first name must be supplied and be between 3 and 50 characters.");

        RuleFor(m => m.Surname)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50)
            .WithMessage("The surname must be supplied and be between 3 and 50 characters.");

        RuleFor(m => m.PolicyReferenceNumber)
            .NotEmpty()
            .Matches(@"^[A-Z]{2}-\d{6}$")
            .WithMessage("The policy reference number must be in the format XX-999999.");

        RuleFor(m => m.Email)
            .Matches(@"^[A-Za-z0-9.]{4,}@[A-Za-z0-9]{2,}\.(com|co\.uk)$")
            .When(m => HasEmail(m.Email))
            .WithMessage("The email address must be in a valid format.");

        RuleFor(m => m)
            .Must(BeEighteen)
            .When(m => HasDob(m.Dob))
            .WithMessage("The policy holder must be at least 18 years old.");

        RuleFor(m => m)
            .Must(HaveEmailOrDob)
            .WithMessage("Either the Email or the Dob must be provided.");
    }

    private bool BeEighteen(RegisterPolicyHolderRequest request)
    {
        if (request.Dob is null)
        {
            return true;
        }

        var age = DateTime.Today.Year - request.Dob.Value.Year;

        if (request.Dob.Value.Date > DateTime.Today.AddYears(-age))
        {
            age--;
        }

        return age >= 18;
    }

    private bool HaveEmailOrDob(RegisterPolicyHolderRequest request)
    {
        return HasEmail(request.Email) || HasDob(request.Dob);
    }

    private bool HasEmail(string? email)
    {
        return !string.IsNullOrEmpty(email);
    }

    private bool HasDob(DateTime? dob)
    {
        return dob != null;
    }
}