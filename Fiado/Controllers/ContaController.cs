using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Fiado.Controllers
{
    public class ContaController : Controller
    {
        public IActionResult Lista()
        {
            return View();
        }
        public IActionResult Nova()
        {
            return View();
        }
        public IActionResult Buscar()
        {
            return View();
        }
    }
}