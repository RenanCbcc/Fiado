using Fiado.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models.NotaModelos
{
    public interface INotaRepositorio
    {
        Task<Nota> GetNoTa(int Id);
        IQueryable<Nota> Notas(int Id);
        Task Atualizar(Nota nota);
        Task Adicionar(Nota nota);
        IQueryable<Nota> Search(NotaBuscaViewModel modelo);
    }
    public class NotaRepositorio : INotaRepositorio
    {
        private readonly FiadoContexto contexto;

        public NotaRepositorio(FiadoContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task Adicionar(Nota nota)
        {
            await contexto.Notas.AddAsync(nota);
            await contexto.SaveChangesAsync();
        }

        public async Task Atualizar(Nota notaAlterada)
        {
            var nota = contexto.Notas.Attach(notaAlterada);
            nota.State = EntityState.Modified;
            await contexto.SaveChangesAsync();
        }

        public async Task<Nota> GetNoTa(int Id)
        {
            return await contexto.Notas.FindAsync(Id);
        }

        public IQueryable<Nota> Notas(int Id)
        {
            return contexto.Notas.Where(n => n.ContaId == Id);
        }

        public IQueryable<Nota> Search(NotaBuscaViewModel modelo)
        {
            throw new NotImplementedException();
        }
    }
}
