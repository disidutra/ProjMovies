using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Services;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class GenreRepository : EfBaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ProjMoviesContext dbContext) : base(dbContext) {
        }
    }
}