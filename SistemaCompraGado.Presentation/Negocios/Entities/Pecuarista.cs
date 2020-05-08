using System;
using System.Runtime.Serialization;

namespace SistemaCompraGado.Presentation.Negocios.Entities
{
    [DataContract]
    public class Pecuarista
    {
        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public string Nome { get; set; }
    }
}
