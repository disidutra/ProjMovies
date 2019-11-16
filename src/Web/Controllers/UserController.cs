using ApplicationCore.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    //[Route("[controller]/[action]")]
    public class UserController : Controller
    {
       // private readonly IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            //_repository = repository;
        }
        public IActionResult Create(){
            
            return View();
        }
    }

}