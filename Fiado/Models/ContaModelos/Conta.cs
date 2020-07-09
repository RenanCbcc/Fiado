using Fiado.Models.ClienteModelos;
using Fiado.Models.NotaModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models.ContaModelos
{
    public class Conta : Base
    {
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public float Total { get; set; }
        public Status Status { get; set; }
        public HashSet<Nota> Notas { get; set; }
    }
}
