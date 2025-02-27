namespace InsuranceRegistration.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<PolicyHolder> PolicyHolders => Set<PolicyHolder>();
}