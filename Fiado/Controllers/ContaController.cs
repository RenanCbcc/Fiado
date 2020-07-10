using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiado.Models;
using Fiado.Models.ContaModelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiado.Controllers
{
    public class ContaController : Controller
    {
        private readonly IContaRepositorio contaRepositorio;

        public ContaController(IContaRepositorio contaRepositorio)
        {
            this.contaRepositorio = contaRepositorio;
        }

        [AllowAnonymous]
        public async Task<ViewResult> Lista(int paginaNumero = 1)
        {
            var listaPaginada = await ListaPaginada<Conta>.CreateAsync(contaRepositorio.Contas(),
                paginaNumero, 10);
            return View(listaPaginada);
        }

        public IActionResult Buscar()
        {
            return View();
        }
    }
}