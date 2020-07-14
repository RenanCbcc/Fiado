using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiado.Models;
using Fiado.Models.ClienteModelos;
using Fiado.Models.ContaModelos;
using Fiado.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiado.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio clienteRepositorio;
        private readonly IContaRepositorio contaRepositorio;

        public ClienteController(IClienteRepositorio clienteRepositorio, IContaRepositorio contaRepositorio)
        {
            this.clienteRepositorio = clienteRepositorio;
            this.contaRepositorio = contaRepositorio;
        }

        [AllowAnonymous]
        public async Task<ViewResult> Lista(int paginaNumero = 1)
        {
            var listaPaginada = await ListaPaginada<Cliente>.CreateAsync(clienteRepositorio.Clientes(),
                paginaNumero, 10);
            return View(listaPaginada);
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Novo(ClienteNovoViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                Cliente cliente = new Cliente
                {
                    Nome = modelo.Nome,
                    Telefone = modelo.Telefone,
                    Endereco = modelo.Endereco,
                    Conta = new Conta()
                };

                await clienteRepositorio.Adicionar(cliente);
                return RedirectToAction("Lista", "Conta");
            }

            return View();
        }

        [HttpGet]
        public async Task<ViewResult> Editar(int Id)
        {
            Cliente cliente = await clienteRepositorio.GetCliente(Id);
            var viewModel = new ClienteEditarViewModel()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Telefone = cliente.Telefone,
                Endereco = cliente.Endereco
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ClienteEditarViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                Cliente cliente = await clienteRepositorio.GetCliente(modelo.Id);
                cliente.Nome = modelo.Nome;
                cliente.Telefone = modelo.Telefone;
                cliente.Endereco = modelo.Endereco;
                await clienteRepositorio.Atualizar(cliente);
                return RedirectToAction("Lista", "Cliente");
            }

            return View();
        }


        [HttpGet]
        public IActionResult Buscar()
        {
            return View("Busca");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ViewResult> Buscar(ClienteBuscaViewModel modelo)
        {
            var clientes = clienteRepositorio.Buscar(modelo);
            var paginatedList = await ListaPaginada<Cliente>.CreateAsync(clientes, 1, 5);
            return View("Lista", paginatedList);
        }


    }
}