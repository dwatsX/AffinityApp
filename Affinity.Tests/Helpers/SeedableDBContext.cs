using Affinity.Data;
using Microsoft.EntityFrameworkCore;

namespace Affinity.Tests.Helpers
{
    public class SeedableDBContext : ApplicationDbContext
    {
        private readonly bool _seedWithApplicationData;

        public SeedableDBContext(DbContextOptions<ApplicationDbContext> options, bool seedWithApplicationData)
            : base(options)
        {
            _seedWithApplicationData = seedWithApplicationData;
        }

        protected override void Seed(ModelBuilder modelBuilder)
        {
            if (_seedWithApplicationData)
            {
                base.Seed(modelBuilder);
            }
        }
    }
}
