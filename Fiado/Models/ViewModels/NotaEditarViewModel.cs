using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models.ViewModels
{
    public class NotaEditarViewModel : NotaNovaViewModel
    {
        public NotaEditarViewModel()
        {
            TituloPagina = "Editar nota";
        }
        public int Id { get; set; }
        public DateTime Data { get; set; }
    }
}
