using System;
using System.Threading.Tasks;
using Fiado.Models;
using Fiado.Models.ContaModelos;
using Fiado.Models.PagamentoModelos;
using Fiado.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiado.Controllers
{
    public class PagamentoController : Controller
    {
        private readonly IPagamentoRepositorio pagamentoRepositorio;
        private readonly IContaRepositorio contaRepositorio;

        public PagamentoController(IPagamentoRepositorio pagamentoRepositorio,
            IContaRepositorio contaRepositorio)
        {
            this.pagamentoRepositorio = pagamentoRepositorio;
            this.contaRepositorio = contaRepositorio;
        }


        [AllowAnonymous]
        public async Task<ViewResult> Lista(int paginaNumero = 1)
        {
            var listaPaginada = await ListaPaginada<Pagamento>.CreateAsync(pagamentoRepositorio.Pagamentos(),
                paginaNumero, 10);
            return View(listaPaginada);
        }


        [HttpGet]
        public async Task<ViewResult> Debitar(int Id)
        {
            var conta = await contaRepositorio.GetConta(Id);
            var modelo = new DebitoViewModel
            {
                ContaId = Id,
                Total = conta.Total
            };

            return View("Debito", modelo);
        }


        [HttpPost]
        public async Task<IActionResult> Debitar(DebitoViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var conta = await contaRepositorio.GetConta(modelo.ContaId);

                if (modelo.Valor > conta.Total)
                {
                    ModelState.AddModelError(string.Empty, "O valor do pagamento não pode ser " +
                        "maior que o total a ser pago.");
                    return View("Debito");
                }

                conta.Total -= modelo.Valor;
                var pagamento = new Pagamento()
                {
                    Atendente = modelo.Atendente,
                    ContaId = conta.Id,
                    Valor = modelo.Valor,
                    Data = DateTime.Now,
                    Detalhes = modelo.Detalhes
                };

                await contaRepositorio.Atualizar(conta);
                await pagamentoRepositorio.Adicionar(pagamento);

                return RedirectToAction("Lista", "Pagamento");
            }

            return View("Debito");
        }
    }
}