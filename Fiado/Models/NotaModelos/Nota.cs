using Fiado.Models.AtendenteModelos;
using Fiado.Models.ClienteModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models.NotaModelos
{
    public class Nota : Base
    {
        [Required]
        public DateTime Data { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int ClienteAtendente { get; set; }
        public Atendente Atendente { get; set; }
        
        [Required]
        public string Detalhes { get; set; }
        
        [Required]
        public float Valor { get; set; }
    }
}
