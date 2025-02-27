using InsuranceRegistration.API.Requests;
using InsuranceRegistration.API.Validators;

namespace InsuranceRegistration.API.Tests.ValidationTests;

public class FirstNameTests
{
    private RegisterPolicyHolderRequestValidator _sut;

    public FirstNameTests()
    {
        _sut = new RegisterPolicyHolderRequestValidator();
    }

    [Fact]
    public void Firstname_Valid_ShouldReturnValid()
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
    [InlineData("so")]
    [InlineData("so simple a beginning endless forms most beautiful and most wonderful have been, and are being, evolved.")]
    public void Firstname_Invalid_ShouldReturnInValid(string value)
    {
        // Arrange.
        var request = new RegisterPolicyHolderRequest
        {
            FirstName = value,
            Surname = "Testname",
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
