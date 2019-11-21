using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.Interfaces.Rental;
using Web.Models;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Index()
        {
            var userId = "001122";

            ViewBag.Title = "Rentals";
            var model = _base_repository_rental.GetAll(x => x.Include(y => y.MovieRentals).ThenInclude(y => y.Movie).Where(x => x.UserId == userId));
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Form(int? id)
        {            
            var resultRental = _base_repository_rental.GetAll(x => x.Include(y => y.MovieRentals).ThenInclude(y => y.Movie).Where(x => x.Id == id)).FirstOrDefault();
            var model = await _base_repository.GetRentalForm(resultRental);

            if(model.Id == 0){
                ViewBag.Title = "Create rental";
            } else {
                ViewBag.Title = "Edit rental";
            }
                        
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(RentalFormViewModel model)
        {
            await _base_repository.AddOrUpdate(model);
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