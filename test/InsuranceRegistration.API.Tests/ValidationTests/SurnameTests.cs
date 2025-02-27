using InsuranceRegistration.API.Requests;
using InsuranceRegistration.API.Validators;

namespace InsuranceRegistration.API.Tests.ValidationTests;

public class SurnameTests
{
    private RegisterPolicyHolderRequestValidator _sut;

    public SurnameTests()
    {
        _sut = new RegisterPolicyHolderRequestValidator();
    }

    [Fact]
    public void Surname_Valid_ShouldReturnValid()
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
    [InlineData("ab")]
    [InlineData("so simple a beginning endless forms most beautiful and most wonderful have been, and are being, evolved.")]
    public void Surname_Invalid_ShouldReturnInValid(string value)
    {
        // Arrange.
        var request = new RegisterPolicyHolderRequest
        {
            Surname = value,
            FirstName = "Testname",
            PolicyReferenceNumber = "AB-123456",
            Email = "test.customer@domain.com",
            Dob = DateTime.Now.AddYears(-19)
        };

        // Act.
        var result = _sut.Validate(request);

        // Assert.
        Assert.False(result.IsValid);
    }
}
