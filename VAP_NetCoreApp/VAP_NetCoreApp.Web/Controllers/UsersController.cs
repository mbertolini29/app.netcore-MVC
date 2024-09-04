using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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
    }
}