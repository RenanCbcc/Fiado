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
    public class NotaController : Controller
    {
        private readonly INotaRepositorio notaRepositorio;
        private readonly IContaRepositorio contaRepositorio;

        public NotaController(INotaRepositorio notaRepositorio, IContaRepositorio contaRepositorio)
        {
            this.notaRepositorio = notaRepositorio;
            this.contaRepositorio = contaRepositorio;
        }

        [AllowAnonymous]
        public async Task<ViewResult> Lista(int Id, int paginaNumero = 1)
        {
            var listaPaginada = await ListaPaginada<Nota>.CreateAsync(notaRepositorio.Notas(Id), paginaNumero, 10);
            return View(listaPaginada);
        }


        [HttpGet]
        public IActionResult Nova(int Id)
        {
            var modelo = new NotaVovaViewModel();
            modelo.ContaId = Id;
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Nova(NotaVovaViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var nota = new Nota
                {
                    ContaId = modelo.ContaId,
                    Valor = modelo.Valor,
                    Atendente = modelo.Atendente,
                    Detalhes = modelo.Detalhes,
                    Data = DateTime.Now
                };

                var conta = await contaRepositorio.GetConta(modelo.ContaId);
                conta.Total += modelo.Valor;
                await notaRepositorio.Adicionar(nota);
                await contaRepositorio.Atualizar(conta);

                return RedirectToAction("Lista", "Conta");
            }
            return View();
        }

        public IActionResult Buscar()
        {
            return View();
        }
    }
}