using System.Data.Entity.ModelConfiguration;
using MoviesCatalog.Data.Models;

namespace MoviesCatalog.Data.Configuration
{
    internal class UserRoleConfiguration : EntityTypeConfiguration<UserRole>
    {
        public UserRoleConfiguration()
        {
            ToTable("UserRoles");
            HasKey(c => new { c.UserId, c.RoleId });
        }
    }
}
