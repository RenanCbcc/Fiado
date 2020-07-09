using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models.AtendenteModelos
{
    public interface IAtendenteRepositorio
    {
        Task<Atendente> GetAtendente(int Id);
    }

    public class AtendenteRepositorio : IAtendenteRepositorio
    {
        public AtendenteRepositorio()
        {

        }

        public Task<Atendente> GetAtendente(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
