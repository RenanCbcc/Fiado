using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiado.Models;
using Fiado.Models.ContaModelos;
using Fiado.Models.NotaModelos;
using Fiado.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiado.Controllers
{
    public class ContaController : Controller
    {
        private readonly IContaRepositorio contaRepositorio;
        private readonly INotaRepositorio notaRepositorio;

        public ContaController(IContaRepositorio contaRepositorio, INotaRepositorio notaRepositorio)
        {
            this.contaRepositorio = contaRepositorio;
            this.notaRepositorio = notaRepositorio;
        }

        [AllowAnonymous]
        public async Task<ViewResult> Lista(int paginaNumero = 1)
        {
            var listaPaginada = await ListaPaginada<Conta>.CreateAsync(contaRepositorio.Contas(),
                paginaNumero, 10);
            return View(listaPaginada);
        }


        [HttpGet]
        public async Task<ViewResult> Editar(int Id)
        {
            var conta = await contaRepositorio.GetConta(Id);
            var viewModel = new ContaEditarViewModel()
            {
                Id = conta.Id,
                Total = conta.Total,
                Status = conta.Status
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ContaEditarViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var conta = await contaRepositorio.GetConta(modelo.Id);
                conta.Status = modelo.Status;
                await contaRepositorio.Atualizar(conta);
                return RedirectToAction("Lista", "Conta");
            }
            return View();
        }

        [HttpGet]
        public async Task<ViewResult> Detalhes(int Id)
        {
            var notas = await notaRepositorio.GetNotas(Id);
            var conta = await contaRepositorio.GetConta(Id);
            var modelo = new ContaDetalhesViewModel()
            {
                Notas = notas,
                Id = conta.Id,
                Status = conta.Status,
                Total = conta.Total

            };
            return View(modelo);
        }

        public IActionResult Buscar()
        {
            return View();
        }
    }
}