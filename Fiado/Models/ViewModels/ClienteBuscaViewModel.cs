using Fiado.Models.ContaModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models.ViewModels
{
    public class ClienteBuscaViewModel
    {
        [StringLength(30)]
        public string Nome { get; set; }
        [StringLength(30)]
        public string Endereco { get; set; }
        public Status? Status { get; set; }


    }
}
