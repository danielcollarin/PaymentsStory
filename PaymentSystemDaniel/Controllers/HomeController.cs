using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentSystemDaniel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystemDaniel.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Home")]
        public ActionResult Home()
        {
            return View();
        }
    }
}
