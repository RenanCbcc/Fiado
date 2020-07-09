using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models
{
    public abstract class Pessoa : Base
    {
        [Required]
        public string Nome { get; set; }
        
    }
}
