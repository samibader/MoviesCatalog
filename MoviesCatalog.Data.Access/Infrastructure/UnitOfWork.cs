using MoviesCatalog.Data.Repositories;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MoviesCatalog.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        IMovieRepository Movies { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }

    internal class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private DbContext _dbContext;
        private DbContext Db => _dbContext ?? (_dbContext = _dbFactory.Init());

        public IMovieRepository Movies { get; private set; }

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
            Movies = new MovieRepository(_dbFactory);
        }
        
        public void SaveChanges()
        {
            Db.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbFactory.Dispose();
        }
    }
}
