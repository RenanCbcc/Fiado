using Fiado.Models.ClienteModelos;
using Fiado.Models.NotaModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models.ContaModelos
{
    public class Conta : Base
    {
        public Conta()
        {
            Notas = new HashSet<Nota>();
        }

        [ForeignKey("Clientes")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }


        [Required]
        public float Total { get; set; }
        [Required]
        public Status Status { get; set; }
        public HashSet<Nota> Notas { get; set; }
    }
}
