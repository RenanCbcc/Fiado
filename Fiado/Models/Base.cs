using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Fiado.Models
{
    public abstract class Base
    {
        [DataMember]
        public int Id { get; set; }        
    }
}
