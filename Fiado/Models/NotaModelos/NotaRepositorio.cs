using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models.NotaModelos
{
    public interface INotaRepositorio
    {
        Task<Nota> GetNoTa(int Id);
    }
    public class NotaRepositorio : INotaRepositorio
    {
        public Task<Nota> GetNoTa(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
