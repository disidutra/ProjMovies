using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using Web.Interfaces.Rental;
using Web.Models;

namespace ApplicationCore.Interfaces.Service
{
    public class RentalFormViewModelService : IRentalFormViewModelService
    {
        private readonly IEfBaseRepository<Rental> _base_repository_rental;
        private readonly IEfBaseRepository<Movie> _base_repository_movie;
        private readonly IEfBaseRepository<MovieRental> _base_repository_movie_rental;

        public RentalFormViewModelService(
            IEfBaseRepository<Rental> baseRepositoryRental,
            IEfBaseRepository<Movie> baseRepositoryMovie,
            IEfBaseRepository<MovieRental> baseRepositoryMovieRental

        )
        {
            _base_repository_movie = baseRepositoryMovie;
            _base_repository_rental = baseRepositoryRental;
            _base_repository_movie_rental = baseRepositoryMovieRental;
        }

        // public async Task<IEnumerable<RentalFormViewModel>> GetAll()
        // {
        //     var listRentals = new List<RentalFormViewModel>();
        //     var resultRentals = await _base_repository_rental.GetAll();
        //     if (resultRentals.Any())
        //     {
        //         foreach (var item in resultRentals)
        //         {
        //             listRentals.Add(
        //                 new RentalFormViewModel()
        //                 {
        //                     Id = item.Id,
        //                     DateRental = item.DateRental,
        //                     UserId = item.UserId
        //                 }
        //             );
        //         }
        //     }

        //     return listRentals;
        // }

        // public async Task<IEnumerable<RentalFormViewModel>> GetAllByUserId()
        // {
        //     var userId = "001122";
            
        //     var listRentals = new List<RentalFormViewModel>();
        //     var resultRentals = await _base_repository_rental.GetAll();
        //     var retalUser = resultRentals.Where(x => x.UserId == userId);
        //     if (resultRentals.Any())
        //     {
        //         foreach (var item in resultRentals)
        //         {
        //             listRentals.Add(
        //                 new RentalFormViewModel()
        //                 {
        //                     Id = item.Id,
        //                     DateRental = item.DateRental,
        //                     UserId = item.UserId
        //                 }
        //             );
        //         }
        //     }

        //     return listRentals;
        // }
        public async Task<RentalFormViewModel> GetRentalForm(Rental obj)
        {
            var result = new RentalFormViewModel();            

            if (obj != null)
            {
                result.Id = obj.Id;
                result.DateRental = obj.DateRental;
                result.UserId = obj.UserId;
            }            

            var resultMoviesAll = await _base_repository_movie.GetAll();

            var listMovies = new List<RentalFormMovieViewModel>();
            foreach (var item in resultMoviesAll)
            {
                listMovies.Add(new RentalFormMovieViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    DateCreated = item.DateCreated,
                    Active = item.Active,
                    GenreId = item.GenreId,
                    // Caso o filme pertença a esse Rental, ele vem setado como True
                    Rental = obj == null ? false : obj.MovieRentals.Where(x=> x.MovieId == item.Id).Any()
                });

            }                       
            result.MovieRentals = listMovies;

            return result;
        }

        public async Task AddOrUpdate(RentalFormViewModel obj)
        {
            obj.UserId = "001122";


            var moviesRental = new List<MovieRental>();
            foreach (var item in obj.MovieRentals.Where(x => x.Rental == true))
            {
                moviesRental.Add(new MovieRental()
                {
                    MovieId = item.Id,
                    RentalId = obj.Id
                });
            }
            var itemAdd = new Rental()
            {
                Id = obj.Id,
                DateRental = DateTime.Now,
                UserId = obj.UserId,
                MovieRentals = moviesRental
            };

            if(itemAdd.Id == 0) {
                itemAdd.DateRental = DateTime.Now;
                await _base_repository_rental.Add(itemAdd);
            } else {
                await _base_repository_rental.Update(itemAdd);
            }
        }
    }
}