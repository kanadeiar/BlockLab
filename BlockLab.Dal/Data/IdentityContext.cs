// dotnet ef --startup-project ../BlockLab/ migrations add init --context IdentityContext

namespace BlockLab.Dal.Data;

public class IdentityContext : IdentityDbContext<User, Role, string>
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    { }
}

