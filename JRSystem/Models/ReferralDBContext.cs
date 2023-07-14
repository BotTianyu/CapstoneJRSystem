using Microsoft.EntityFrameworkCore;

namespace JRSystem.Models
{
    public class ReferralDBContext : DbContext
    {
        public ReferralDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Referral> ReferralSets { get; set; }

        public DbSet<Account> AccountSets { get; set; }

        public DbSet<Application> ApplicationSets { get; set; }

    }
}
