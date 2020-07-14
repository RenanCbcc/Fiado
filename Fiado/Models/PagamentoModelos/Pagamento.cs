using Fiado.Models.AtendenteModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models.PagamentoModelos
{
    public class Pagamento : Base
    {
        [ForeignKey("Contas")]
        public int ContaId { get; set; }

        [Required]
        public float Valor { get; set; }
        [Required]
        public Atendente Atendente { get; set; }
        [Required]
        public DateTime Data { get; set; }
        public string Detalhes { get; set; }
    }
}
