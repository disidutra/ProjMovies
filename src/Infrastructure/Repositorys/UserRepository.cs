using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Services;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class UserRepository : EfBaseRepository<User>, IUserRepository
    {
        public UserRepository(ProjMoviesContext dbContext) : base(dbContext){}
    }
}