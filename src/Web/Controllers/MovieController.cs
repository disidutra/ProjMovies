using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IEfBaseRepository<Movie> _base_repository;
        private readonly IEfBaseRepository<Genre> _base_repository_genre;
        private readonly IMovieRepository _base_repository_movie;
        public MovieController(
            IEfBaseRepository<Movie> baseRepository,
            IEfBaseRepository<Genre> baseRepositoryGenre,
            IMovieRepository baseRepositoryMovie
        )
        {
            _base_repository = baseRepository;
            _base_repository_genre = baseRepositoryGenre;
            _base_repository_movie = baseRepositoryMovie;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Movies";            
            var model = await _base_repository_movie.GetAll();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Form(int? id)
        {
            var genres = await _base_repository_genre.GetAll();
            ViewBag.GenreList = genres.OrderBy(x => x.Name).Select(
                t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Name + (t.Active ? "" : " - Inactive")
                });

            if (id != null)
            {
                var model = await _base_repository.GetById(id ?? 0);
                if (model != null)
                {
                    ViewBag.Title = "Edit movie";
                    return View(model);
                }

            }

            ViewBag.Title = "Create movie";
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(Movie model)
        {
            if (model.Id != 0)
            {
                await _base_repository.Update(model);
            }
            else
            {
                model.DateCreated = DateTime.Now;
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