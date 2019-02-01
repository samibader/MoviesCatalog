using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MoviesCatalog.Data.Infrastructure;
using MoviesCatalog.Data.Models;

namespace MoviesCatalog.Data.Repositories
{
    public interface IUserClaimRepository : IRepository<UserClaim>
    {
        Task<List<UserClaim>> GetByUserId(int userId);
    }

    internal class UserClaimRepository : RepositoryBase<UserClaim>, IUserClaimRepository
    {
        public UserClaimRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Task<List<UserClaim>> GetByUserId(int userId)
        {
            return dbSet.Where(uc => uc.UserId == userId).ToListAsync();
        }
    }
}
