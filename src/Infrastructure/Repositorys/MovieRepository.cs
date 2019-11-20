using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Services;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class MovieRepository: EfBaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ProjMoviesContext dbContext) : base(dbContext){}
    }
}