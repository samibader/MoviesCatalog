using System.Data.Entity.ModelConfiguration;
using MoviesCatalog.Data.Models;

namespace MoviesCatalog.Data.Configuration
{
    internal class UserLoginConfiguration : EntityTypeConfiguration<UserLogin>
    {
        public UserLoginConfiguration()
        {
            ToTable("UserLogins");
            HasKey(c => new
            {
                c.LoginProvider, c.ProviderKey, c.UserId
            });
        }
    }
}
