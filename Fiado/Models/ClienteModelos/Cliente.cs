using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models.ClienteModelos
{
    public class Cliente : Pessoa
    {
        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Endereco { get; set; }
    }
}
