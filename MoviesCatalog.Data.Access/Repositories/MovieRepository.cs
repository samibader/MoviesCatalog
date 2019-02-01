using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MoviesCatalog.Data.Infrastructure;
using MoviesCatalog.Data.Models;

namespace MoviesCatalog.Data.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetFeaturedMoviesAsync();
    }

    internal class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {
        public MovieRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public async Task<IEnumerable<Movie>> GetFeaturedMoviesAsync()
        {
            return await dbSet.ToListAsync();
        }
        
    }
}
