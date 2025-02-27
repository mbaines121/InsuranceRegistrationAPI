using InsuranceRegistration.API.Requests;
using InsuranceRegistration.API.Validators;
using Newtonsoft.Json.Linq;

namespace InsuranceRegistration.API.Tests.ValidationTests;

public class ConditionalTests
{
    private RegisterPolicyHolderRequestValidator _sut;

    public ConditionalTests()
    {
        _sut = new RegisterPolicyHolderRequestValidator();
    }

    [Fact]
    public void Conditional_Dob_Only_ShouldReturnValid()
    {
        // Arrange.
        var request = new RegisterPolicyHolderRequest
        {
            FirstName = "Testname",
            Surname = "Testname",
            PolicyReferenceNumber = "AB-123456",
            Email = null,
            Dob = DateTime.Now.AddYears(-19)
        };

        // Act.
        var result = _sut.Validate(request);

        // Assert.
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Conditional_Email_Only_ShouldReturnValid()
    {
        // Arrange.
        var request = new RegisterPolicyHolderRequest
        {
            FirstName = "Testname",
            Surname = "Testname",
            PolicyReferenceNumber = "AB-123456",
            Email = "test.customer@domain.com",
            Dob = null
        };

        // Act.
        var result = _sut.Validate(request);

        // Assert.
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Conditional_Both_ShouldReturnValid()
    {
        // Arrange.
        var request = new RegisterPolicyHolderRequest
        {
            FirstName = "Testname",
            Surname = "Testname",
            PolicyReferenceNumber = "AB-123456",
            Email = "test.customer@domain.com",
            Dob = DateTime.Now.AddYears(-19)
        };

        // Act.
        var result = _sut.Validate(request);

        // Assert.
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Conditional_Neither_ShouldReturnInValid()
    {
        // Arrange.
        var request = new RegisterPolicyHolderRequest
        {
            FirstName = "Testname",
            Surname = "Testname",
            PolicyReferenceNumber = "AB-123456",
            Email = null,
            Dob = null
        };

        // Act.
        var result = _sut.Validate(request);

        // Assert.
        Assert.False(result.IsValid);
    }
}
