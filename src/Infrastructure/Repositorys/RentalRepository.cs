using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Services;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class RentalRepository: EfBaseRepository<Rental>, IRentalRepository
    {
        public RentalRepository(ProjMoviesContext dbContext) : base(dbContext){}
    }
}