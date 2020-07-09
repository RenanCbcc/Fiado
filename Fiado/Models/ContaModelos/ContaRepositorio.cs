using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models.ContaModelos
{
    public interface IContaRepositorio
    {
        Task<Conta> GetConta(int Id);
    }
    public class ContaRepositorio : IContaRepositorio
    {
        public Task<Conta> GetConta(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
