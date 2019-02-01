using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using MoviesCatalog.Data.Models;

namespace MoviesCatalog.Data.Configuration
{
    internal class MovieConfiguration : EntityTypeConfiguration<Movie>
    {
        public MovieConfiguration()
        {
            ToTable("Movies");
            Property(c => c.Description)
                .HasMaxLength(5000);
            Property(c => c.Name)
                .HasMaxLength(256)
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("MovieNameIndex") { IsUnique = true }));
        }
    }
}
