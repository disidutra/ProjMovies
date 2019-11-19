using System;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class RentalController : Controller
    {
        private readonly IEfBaseRepository<Rental> _base_repository;
        public RentalController(IEfBaseRepository<Rental> baseRepository)
        {
            _base_repository = baseRepository;
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

            if (id != null)
            {
                var model = await _base_repository.GetById(id ?? 0);
                if (model != null)
                {
                    ViewBag.Title = "Edit Rental";
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
    }
}