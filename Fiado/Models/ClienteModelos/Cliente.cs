using Fiado.Models.ContaModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models.ClienteModelos
{
    public class Cliente : Base
    {   
        public int ContaId { get; set; }
        public Conta Conta { get; set; }

        [Required]
        public string Nome { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Endereco { get; set; }
    }
}
