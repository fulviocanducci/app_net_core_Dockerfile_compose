using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using app_net_docker.Models;
using app_net_docker.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace app_net_docker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Db db;

        public HomeController(ILogger<HomeController> logger, Db db)
        {
            this.db = db;
            _logger = logger;
        }

        public IActionResult Index()
        {

            Todo todo = new Todo() 
            {
                Description = Guid.NewGuid().ToString()
            };
            db.Todo.Add(todo);
            db.SaveChanges();
            return View(db.Todo.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
