using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    //[Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IEfBaseRepository<User> _base_repository;
        public UserController(IEfBaseRepository<User> baseRepository)
        {
            _base_repository = baseRepository;
        }

        [HttpGet]
        public IActionResult Create(){
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User model)
        {       
            await _base_repository.Add(model);
            return RedirectToAction("Index", "Rental");
        }
    }

}