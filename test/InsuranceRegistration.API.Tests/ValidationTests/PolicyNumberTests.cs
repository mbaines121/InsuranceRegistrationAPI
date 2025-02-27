using InsuranceRegistration.API.Requests;
using InsuranceRegistration.API.Validators;

namespace InsuranceRegistration.API.Tests.ValidationTests;

public  class PolicyNumberTests
{
    private RegisterPolicyHolderRequestValidator _sut;

    public PolicyNumberTests()
    {
        _sut = new RegisterPolicyHolderRequestValidator();
    }

    [Fact]
    public void PolicyNumber_Valid_ShouldReturnValid()
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

    [Theory]
    [InlineData("")]
    [InlineData("invalid")]
    [InlineData("AB-12345")]
    [InlineData("AB-1234567")]
    [InlineData("ab-123456")]
    [InlineData("ab=123456")]
    [InlineData("a-123456")]
    [InlineData("12-123456")]
    public void PolicyNumber_Invalid_ShouldReturnInValid(string value)
    {
        // Arrange.
        var request = new RegisterPolicyHolderRequest
        {
            FirstName = "Testname",
            Surname = "Testname",
            PolicyReferenceNumber = value,
            Email = "test.customer@domain.com",
            Dob = DateTime.Now.AddYears(-19)
        };

        // Act.
        var result = _sut.Validate(request);

        // Assert.
        Assert.False(result.IsValid);
    }
}
