using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models
{
    public class ListaPaginada<T> : List<T>
    {
        public int PaginaIndice { get; private set; }
        public int TotalPaginas { get; set; }
        
        public bool PaginaAnterior
        {
            get
            {
                return (PaginaIndice > 1);
            }
        }
        public bool ProximaPagina
        {
            get
            {
                return (PaginaIndice < TotalPaginas);
            }
        }

        public ListaPaginada(List<T> items, int contador, int paginaIndice, int paginaTamanho)
        {
            PaginaIndice = paginaIndice;
            TotalPaginas = (int)Math.Ceiling(contador / (double)paginaTamanho);
            this.AddRange(items);
        }

        public static async Task<ListaPaginada<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new ListaPaginada<T>(items, count, pageIndex, pageSize);
        }

    }
}
