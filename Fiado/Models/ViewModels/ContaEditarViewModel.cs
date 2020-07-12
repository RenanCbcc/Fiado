using Fiado.Models.ContaModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models.ViewModels
{
    public class ContaEditarViewModel
    {
        public int Id { get; set; }
        public float Total { get; set; }
        [Required]
        public Status Status { get; set; }

    }
}
