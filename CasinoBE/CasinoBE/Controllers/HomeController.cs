using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.DataModels;

namespace CasinoBE.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new Player { FirstName = "Md.Nafis", LastName = "Sadik", UserName = "Nafis" });
        }
    }
}
