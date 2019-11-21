using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Repository
{
    public interface IMovieRepository
    {
        Task<IEnumerable<MovieGenre>> GetAll();
    }
}