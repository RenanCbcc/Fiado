using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Fiado.Controllers
{
    public class NotaController : Controller
    {
        public IActionResult Index()
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