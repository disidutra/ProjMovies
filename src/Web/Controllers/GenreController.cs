using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class GenreController : Controller
    {
        private readonly IEfBaseRepository<Genre> _base_repository;
        public GenreController(IEfBaseRepository<Genre> baseRepository)
        {
            _base_repository = baseRepository;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Genres";
            var model = await _base_repository.GetAll();
            return View(model.OrderBy(x => x.Name));
        }

        [HttpGet]
        public async Task<IActionResult> Form(int? id)
        {
            if (id != null)
            {
                var model = await _base_repository.GetById(id ?? 0);
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