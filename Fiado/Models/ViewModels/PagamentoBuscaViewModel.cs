using Fiado.Models.AtendenteModelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace Fiado.Models.ViewModels
{
    public class PagamentoBuscaViewModel
    {
        public PagamentoBuscaViewModel()
        {
            TituloPagina = "Buscar pagamento";
        }

        public string TituloPagina { get; set; }
        public Atendente? Atendente { get; set; }

        [DataType(DataType.Currency)]
        public float? MaiorQue { get; set; }
        [DataType(DataType.Currency)]
        public float? MenorQue { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Data { get; set; }

    }
}
