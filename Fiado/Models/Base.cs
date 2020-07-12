using System.Runtime.Serialization;

namespace Fiado.Models
{
    public abstract class Base
    {
        [DataMember]        
        public int Id { get; set; }        
    }
}
