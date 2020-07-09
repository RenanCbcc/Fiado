using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiado.Models.ClienteModelos;
using Microsoft.AspNetCore.Mvc;

namespace Fiado.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio clienteRepositorio;

        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            this.clienteRepositorio = clienteRepositorio;
        }
        public IActionResult Lista()
        {
            return View();
        }

        public IActionResult Novo()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult Buscar()
        {
            return View();
        }

    }
}