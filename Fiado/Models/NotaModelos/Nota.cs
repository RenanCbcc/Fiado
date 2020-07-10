using Fiado.Models.AtendenteModelos;
using Fiado.Models.ClienteModelos;
using Fiado.Models.ContaModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models.NotaModelos
{
    public class Nota : Base
    {

        [ForeignKey("Contas")]
        public int ContaId { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public Atendente Atendente { get; set; }

        [Required]
        public float Valor { get; set; }

        public string Detalhes { get; set; }

    }
}
