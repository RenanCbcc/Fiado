using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models.ViewModels
{
    public class ContaNovaViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Nome não pode exceder 50 caracteres.")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage = "Número de telefone não pode exceder 11 caracteres.")]
        public string Telefone { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Endereço não pode exceder 100 caracteres.")]
        public string Endereco { get; set; }
    }
}
