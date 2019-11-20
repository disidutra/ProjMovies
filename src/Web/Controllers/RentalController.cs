using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.Interfaces.Rental;
using Web.Models;

namespace Web.Controllers
{
    public class RentalController : Controller
    {

        private readonly IRentalFormViewModelService _base_repository;
        private readonly IEfBaseRepository<Rental> _base_repository_rental;
        public RentalController(
            IRentalFormViewModelService baseRepository,
            IEfBaseRepository<Rental> baseRepositoryRental
            )
        {
            _base_repository = baseRepository;
            _base_repository_rental = baseRepositoryRental;
            
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
            var resultModel = await _base_repository.GetById(id);
            ViewBag.Title = "Create rental";
            resultModel.UserId = "001122";

            return View(resultModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(RentalFormViewModel model)
        {
            await _base_repository.Add(model);
            // if (model.Id != 0)
            // {
            //     await _base_repository.Update(model);
            // }
            // else
            // {
            //     model.DateRental = DateTime.Now;
            //     await _base_repository.Add(model);
            
            // }

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _base_repository_rental.GetById(id);
            if (item != null)
            {
                await _base_repository_rental.Remove(item);
                return NoContent();
            }
            return NoContent();
        }
    }
}