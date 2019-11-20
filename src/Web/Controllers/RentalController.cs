using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class RentalController : Controller
    {
        private readonly IEfBaseRepository<Rental> _base_repository;
        private readonly IEfBaseRepository<Movie> _base_repository_movie;
        public RentalController(
            IEfBaseRepository<Rental> baseRepository,
            IEfBaseRepository<Movie> baseRepositoryMovie
            )
        {
            _base_repository = baseRepository;
            _base_repository_movie = baseRepositoryMovie;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Rentals";
            var model = await _base_repository.GetAll();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Form(int? id)
        {
            var movies = await _base_repository_movie.GetAll();
            ViewBag.MovieList = movies.OrderBy(x => x.Name);
            if (id != null)
            {
                var model = await _base_repository.GetById(id ?? 0);
                if (model != null)
                {
                    ViewBag.Title = "Edit rental";
                    return View(model);
                }
            }
            ViewBag.Title = "Create rental";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(Rental model)
        {
            if (model.Id != 0)
            {
                await _base_repository.Update(model);
            }
            else
            {
                model.DateRental = DateTime.Now;
                await _base_repository.Add(model);
            }

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _base_repository.GetById(id);
            if (item != null)
            {
                await _base_repository.Remove(item);
                return NoContent();
            }
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRange(IEnumerable<int> items)
        {
            var itemsDelete = await _base_repository.GetRangeById(items);
            
            if (itemsDelete.Any())
            {
                await _base_repository.RemoveRange(itemsDelete);
                return NoContent();
            }
            return NoContent();
        }
    }
}