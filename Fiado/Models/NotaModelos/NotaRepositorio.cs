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
        Task<Nota> GetNota(int Id);

        Task<List<Nota>> GetNotas(int Id);
        IQueryable<Nota> Notas(int Id);
        Task Atualizar(Nota nota);
        Task Adicionar(Nota nota);
        IQueryable<Nota> Buscar(NotaBuscaViewModel modelo);
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

        public async Task<Nota> GetNota(int Id)
        {
            return await contexto.Notas.FindAsync(Id);
        }

        public async Task<List<Nota>> GetNotas(int Id)
        {
            return await contexto.Notas.Where(n => n.ContaId == Id).ToListAsync();
        }

        public IQueryable<Nota> Notas(int Id)
        {
            return contexto.Notas.Where(n => n.ContaId == Id);
        }

        public IQueryable<Nota> Buscar(NotaBuscaViewModel modelo)
        {
            var query = "SELECT * FROM Notas WHERE ";
            if (modelo.Atendente != null)
            {
                query += "Atendente = @p0 AND ";
            }
            if (modelo.MenorQue != null)
            {
                query += "Valor < @p1 AND ";
            }
            if (modelo.MaiorQue != null)
            {
                query += "Valor > @p2 AND ";
            }
            if (modelo.Data != null)
            {
                query += "[Data] = @p3 AND ";
            }
            query += "1 = 1";
            return contexto.Notas.FromSql(query, modelo.Atendente, modelo.MenorQue, modelo.MaiorQue, modelo.Data);


        }
    }
}
