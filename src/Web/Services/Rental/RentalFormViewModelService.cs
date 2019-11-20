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

        public async Task<IEnumerable<RentalFormViewModel>> GetAll()
        {
            var listRentals = new List<RentalFormViewModel>();
            var resultRentals = await _base_repository_rental.GetAll();
            if (resultRentals.Any())
            {
                foreach (var item in resultRentals)
                {
                    listRentals.Add(
                        new RentalFormViewModel()
                        {
                            Id = item.Id,
                            DateRental = item.DateRental,
                            UserId = item.UserId
                        }
                    );
                }
            }

            return listRentals;
        }
        public async Task<RentalFormViewModel> GetById(int? id)
        {
            var resultView = new RentalFormViewModel();
            var resultRental = new Rental();

            // Busca a lista de filmes disponíveis
            var resultMoviesAll = await _base_repository_movie.GetAll();

            // Busca toda lista da tabela RentalMovie
            //var resultMoviesRental = await _base_repository_movie_rental.GetAll();

            // Busca Rental caso exista, para editar
            if (id != null)
            {
                resultRental = await _base_repository_rental.GetById(id ?? 0);
                if (resultRental != null)
                {
                    resultView.Id = resultRental.Id;
                    resultView.DateRental = resultRental.DateRental;
                    resultView.UserId = resultRental.UserId;
                }
            }

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
                    Rental = false//esultMoviesRental.Where(x => x.MovieId == item.Id || x.RentalId == resultRental.Id).Any() ? true : false
                });

            }
            resultView.MovieRentals = listMovies;

            return resultView;
        }

        public async Task Add(RentalFormViewModel obj)
        {

            var moviesRental = new List<MovieRental>();
            foreach (var item in obj.MovieRentals.Where(x => x.Rental == true))
            {
                moviesRental.Add(new MovieRental()
                {
                    MovieId = item.Id
                });
            }
            var itemAdd = new Rental()
            {
                Id = obj.Id,
                DateRental = DateTime.Now,
                UserId = obj.UserId,
                MovieRentals = moviesRental
            };

            await _base_repository_rental.Add(itemAdd);
        }
    }
}