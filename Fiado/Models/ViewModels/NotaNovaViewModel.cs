using Fiado.Models.AtendenteModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models.ViewModels
{
    public class NotaNovaViewModel
    {
        public NotaNovaViewModel()
        {
            TituloPagina = "Novo nota";
        }

        public int ContaId { get; set; }

        [Required(ErrorMessage = "A nota precia ter um atendente.")]
        public Atendente Atendente { get; set; }

        [Required(ErrorMessage = "Nota precisa ter um valor.")]
        [Range(minimum: 0.1, maximum: 200.0, ErrorMessage = "Valor deve estar entre R$ 0.1 e R$ 200.00")]
        public float Valor { get; set; }

        [StringLength(200)]
        public string Detalhes { get; set; }

        public string TituloPagina { get; set; }
    }
}
