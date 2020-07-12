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
            var modelo = new NotaNovaViewModel();
            modelo.ContaId = Id;
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Nova(NotaNovaViewModel modelo)
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


        [HttpGet]
        public async Task<IActionResult> Editar(int Id)
        {
            var nota = await notaRepositorio.GetNota(Id);
            var modelo = new NotaEditarViewModel()
            {
                ContaId = nota.ContaId,
                Data = nota.Data,
                Atendente = nota.Atendente,
                Valor = nota.Valor,
                Detalhes = nota.Detalhes
            };
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(NotaEditarViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var nota = await notaRepositorio.GetNota(modelo.Id);                
                var conta = await contaRepositorio.GetConta(modelo.ContaId);
                conta.Total -= nota.Valor;
                conta.Total += modelo.Valor;
                nota.Detalhes = modelo.Detalhes;
                nota.Valor = modelo.Valor;

                await notaRepositorio.Atualizar(nota);
                await contaRepositorio.Atualizar(conta);
                return RedirectToAction("Detalhes", "Conta", new { id = conta.Id });
            }
            return View();
        }

        public IActionResult Buscar()
        {
            return View();
        }
    }
}