using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompraGado.Domain.Entities
{
    public class CompraGadoItem
    {
        public long ID { get; set; }
        public string Quantidade { get; set; }
        public long CompraGadoID { get; set; }
        public long AnimalID { get; set; }
        public CompraGado CompraGado { get; set; }
        public Animal Animal { get; set; }
    }
}
