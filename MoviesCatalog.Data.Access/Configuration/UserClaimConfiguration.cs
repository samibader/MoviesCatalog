using System.Data.Entity.ModelConfiguration;
using MoviesCatalog.Data.Models;

namespace MoviesCatalog.Data.Configuration
{
    internal class UserClaimConfiguration : EntityTypeConfiguration<UserClaim>
    {
        public UserClaimConfiguration()
        {
            ToTable("UserClaims");
        }
    }
}
