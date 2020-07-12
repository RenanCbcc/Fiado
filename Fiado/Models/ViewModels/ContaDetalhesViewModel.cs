using Fiado.Models.ContaModelos;
using Fiado.Models.NotaModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models.ViewModels
{
    public class ContaDetalhesViewModel
    {
        
        public int Id { get; set; }

        [Required]
        public float Total { get; set; }

        [Required]
        public float Pagamento { get; set; }

        public Status Status { get; set; }

        public List<Nota> Notas { get; set; }
    }
}
