using InsuranceRegistration.API.Requests;
using InsuranceRegistration.API.Validators;

namespace InsuranceRegistration.API.Tests.ValidationTests;

public class EmailTests
{
    private RegisterPolicyHolderRequestValidator _sut;

    public EmailTests()
    {
        _sut = new RegisterPolicyHolderRequestValidator();
    }

    [Theory]
    [InlineData("test.customer@domain.com")]
    [InlineData("test.customer@domain.co.uk")]
    [InlineData("abcd@ab.co.uk")]
    [InlineData("abcd@ab.com")]
    [InlineData("ab12@a1.com")]
    public void Email_Valid_ShouldReturnValid(string value)
    {
        // Arrange.
        var request = new RegisterPolicyHolderRequest
        {
            FirstName = "Testname",
            Surname = "Testname",
            PolicyReferenceNumber = "AB-123456",
            Email = value,
            Dob = null
        };

        // Act.
        var result = _sut.Validate(request);

        // Assert.
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData("abv@ab.com")]
    [InlineData("abcd@a.com")]
    [InlineData("abv@ab.co.uk")]
    [InlineData("abcd@a.co.uk")]
    [InlineData("ab.d@a.co.uk")]
    public void Email_Invalid_ShouldReturnInValid(string value)
    {
        // Arrange.
        var request = new RegisterPolicyHolderRequest
        {
            FirstName = "Testname",
            Surname = "Testname",
            PolicyReferenceNumber = "AB-123456",
            Email = value,
            Dob = null
        };

        // Act.
        var result = _sut.Validate(request);

        // Assert.
        Assert.False(result.IsValid);
    }
}
