using Fiado.Models.AtendenteModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models.ViewModels
{
    public class NotaBuscaViewModel
    {
        public NotaBuscaViewModel()
        {
            TituloPagina = "Buscar Nota";
        }
        public int ContaId { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? Data { get; set; }
        [DataType(DataType.Currency)]
        public float? MaiorQue { get; set; }
        [DataType(DataType.Currency)]
        public float? MenorQue { get; set; }
        public Atendente? Atendente { get; set; }
        public string TituloPagina { get; set; }
    }
}
