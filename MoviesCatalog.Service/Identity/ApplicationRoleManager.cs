using Microsoft.AspNet.Identity;
using MoviesCatalog.Data.Identity;
using MoviesCatalog.Data.Models;

namespace MoviesCatalog.Service.Identity
{
    public class ApplicationRoleManager : RoleManager<Role, int>
    {
        public ApplicationRoleManager(IRoleStore store) : base(store)
        {
        }
    }
}
