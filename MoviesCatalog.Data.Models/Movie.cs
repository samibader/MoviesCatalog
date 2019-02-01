using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesCatalog.Data.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public string Director { get; set; }
        public int ReleaseYear { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
