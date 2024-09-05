using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VAP_NetCoreApp.Models;
using VAP_NetCoreApp.Models.Queries;
using VAP_NetCoreApp.Web.Models;

namespace VAP_NetCoreApp.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly Database _database;
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
            _database = new Database();
        }

        //acciones, metodos que son invocados,
        //cuando hay una peticion https por parte del usuario.
        public IActionResult Index()
        {
            return View(_database.Users.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            var result = _database.Users.Create(user); 
            if(!result.Success)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(user);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}