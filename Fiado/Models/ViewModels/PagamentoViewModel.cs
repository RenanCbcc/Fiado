﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models.ViewModels
{
    public class PagamentoViewModel
    {
        public float Total { get; set; }

        [Required(ErrorMessage = "Pagamento precisa ter um valor.")]
        [Range(minimum: 0.1, maximum: 200.0, ErrorMessage = "Valor deve estar entre R$ 0.1 e R$ 200.00")]
        public float Valor { get; set; }
    }
}
