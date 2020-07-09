using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models.ClienteModelos
{
    public interface IClienteRepositorio
    {
        Task<Cliente> GetCliente(int Id);
    }

    public class ClienteRepositorio : IClienteRepositorio
    {
        public ClienteRepositorio()
        {

        }
               

        Task<Cliente> IClienteRepositorio.GetCliente(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
