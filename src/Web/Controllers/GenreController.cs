using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreRepository _repository;
        public GenreController(IGenreRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Genres";
            var model = await _repository.GetAll();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Form(int? id)
        {

            if (id != null)
            {
                var model = await _repository.GetById(id ?? 0);
                if (model != null)
                {
                    ViewBag.Title = "Edit genre";
                    return View(model);
                }

            }
            ViewBag.Title = "Create genre";
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(Genre model)
        {
            if (model.Id != 0)
            {
                await _repository.Update(model);
            }
            else
            {
                model.DateCreated = DateTime.Now;
                await _repository.Add(model);
            }

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _repository.GetById(id);
            if (item != null)
            {
                await _repository.Remove(item);
                return NoContent();
            }
            return NoContent();
        }
    }
}