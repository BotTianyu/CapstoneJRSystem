using Microsoft.EntityFrameworkCore;

namespace JRSystem.Models
{
    public class ReferralDBContext : DbContext
    {
        public ReferralDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Referral> ReferralSets { get; set; }
        
        
    }
}
