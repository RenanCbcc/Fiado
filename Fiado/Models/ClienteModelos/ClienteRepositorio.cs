using Fiado.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models.ClienteModelos
{
    public interface IClienteRepositorio
    {
        Task<Cliente> GetCliente(int Id);
        IQueryable<Cliente> Clientes();
        Task Adicionar(Cliente cliente);
        Task Atualizar(Cliente cliente);
        IQueryable<Cliente> Buscar(ClienteBuscaViewModel modelo);

    }

    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly FiadoContexto contexto;

        public ClienteRepositorio(FiadoContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task Adicionar(Cliente cliente)
        {
            await contexto.Clientes.AddAsync(cliente);
            await contexto.SaveChangesAsync();
        }

        public async Task Atualizar(Cliente clienteAlterado)
        {
            var cliente = contexto.Clientes.Attach(clienteAlterado);
            cliente.State = EntityState.Modified;
            await contexto.SaveChangesAsync();
        }

        public IQueryable<Cliente> Clientes()
        {
            return contexto.Clientes;
        }

        public async Task<Cliente> GetCliente(int Id)
        {
            return await contexto.Clientes.FindAsync(Id);
        }

        public IQueryable<Cliente> Buscar(ClienteBuscaViewModel modelo)
        {
            var query = "SELECT CL.ContaId,CL.Endereco,CL.Id,CL.Nome,CL.Telefone " +
                "FROM dbo.Clientes CL JOIN dbo.Contas CO on CL.ContaId = CO.Id WHERE ";
            if (modelo.Nome != null)
            {
                query += "Nome LIKE '%'+ @p0 +'%' AND ";
            }
            if (modelo.Endereco != null)
            {
                query += "Endereco LIKE '%'+ @p1 +'%' AND ";
            }
            if (modelo.Status != null)
            {
                query += "Status = @p2 AND ";
            }

            query += "1 = 1";
            return contexto.Clientes.FromSqlRaw(query, modelo.Nome, modelo.Endereco, modelo.Status);
        }

    }
}
