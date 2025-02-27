using System.ComponentModel.DataAnnotations;

namespace InsuranceRegistration.Infrastructure.Models;

public class PolicyHolder
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = default!;

    [Required]
    [MaxLength(50)]
    public string Surname { get; set; } = default!;

    [Required]
    [MaxLength(9)]
    public string PolicyReferenceNumber { get; set; } = default!;

    [MaxLength(250)]
    public string? Email { get; set; }

    public DateTime? Dob { get; set; }
}
