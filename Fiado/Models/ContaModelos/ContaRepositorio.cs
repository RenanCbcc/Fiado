using Fiado.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models.ContaModelos
{
    public interface IContaRepositorio
    {
        Task<Conta> GetConta(int Id);
        IQueryable<Conta> Contas();
        Task Adicionar(Conta conta);
        Task Atualizar(Conta conta);
        IQueryable<Conta> Search(ContasBuscaViewModel modelo);

    }
    public class ContaRepositorio : IContaRepositorio
    {
        private readonly FiadoContexto contexto;

        public ContaRepositorio(FiadoContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task Adicionar(Conta conta)
        {
            await contexto.Contas.AddAsync(conta);
            await contexto.SaveChangesAsync();
        }

        public async Task Atualizar(Conta contaAlterada)
        {
            var conta = contexto.Contas.Attach(contaAlterada);
            conta.State = EntityState.Modified;
            await contexto.SaveChangesAsync();
        }

        public IQueryable<Conta> Contas()
        {
            return contexto.Contas
                .Include(c => c.Cliente);
        }

        public Task<Conta> GetConta(int Id)
        {
            return contexto.Contas.FindAsync(Id);
        }

        public IQueryable<Conta> Search(ContasBuscaViewModel modelo)
        {
            throw new NotImplementedException();
        }
    }
}
