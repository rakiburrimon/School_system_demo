using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hornets.Controllers
{
    public class Admission : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult academic_fees()
        {
            return View();
        }
        public IActionResult admission_info()
        {
            return View();
        }
        public IActionResult admission_going_on()
        {
            return View();
        }

    }
}
