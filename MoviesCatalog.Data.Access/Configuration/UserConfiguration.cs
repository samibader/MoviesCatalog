using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using MoviesCatalog.Data.Models;

namespace MoviesCatalog.Data.Configuration
{
    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users");
            Property(c => c.Email)
                .HasMaxLength(256);
            Property(c => c.UserName)
                .HasMaxLength(256)
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UserNameIndex") { IsUnique = true }));
        }
    }
}
