using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCompraGado.Presentation.Negocios.Entities
{
    public class CompraGadoItem
    {
        public long ID { get; set; }
        public string Quantidade { get; set; }
        public long CompraGadoID { get; set; }
        public long AnimalID { get; set; }
    }
}
