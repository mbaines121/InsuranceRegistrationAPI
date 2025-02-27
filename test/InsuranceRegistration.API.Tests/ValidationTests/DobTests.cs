using InsuranceRegistration.API.Requests;
using InsuranceRegistration.API.Validators;

namespace InsuranceRegistration.API.Tests.ValidationTests;

public class DobTests
{
    private RegisterPolicyHolderRequestValidator _sut;

    public DobTests()
    {
        _sut = new RegisterPolicyHolderRequestValidator();
    }

    public static TheoryData<DateTime?> ValidData = new TheoryData<DateTime?>
    {
        null,
        DateTime.Now.AddYears(-19)
    };

    public static TheoryData<DateTime?> InvalidData = new TheoryData<DateTime?>
    {
        DateTime.Now.AddYears(-17),
    };

    [Theory]
    [MemberData(nameof(ValidData))]
    public void Email_Valid_ShouldReturnValid(DateTime? value)
    {
        // Arrange.
        var request = new RegisterPolicyHolderRequest
        {
            FirstName = "Testname",
            Surname = "Testname",
            PolicyReferenceNumber = "AB-123456",
            Email = "test.customer@domain.com",
            Dob = value
        };

        // Act.
        var result = _sut.Validate(request);

        // Assert.
        Assert.True(result.IsValid);
    }

    [Theory]
    [MemberData(nameof(InvalidData))]
    public void Email_Invalid_ShouldReturnInValid(DateTime? value)
    {
        // Arrange.
        var request = new RegisterPolicyHolderRequest
        {
            FirstName = "Testname",
            Surname = "Testname",
            PolicyReferenceNumber = "AB-123456",
            Email = "test.customer@domain.com",
            Dob = value
        };

        // Act.
        var result = _sut.Validate(request);

        // Assert.
        Assert.False(result.IsValid);
    }
}
