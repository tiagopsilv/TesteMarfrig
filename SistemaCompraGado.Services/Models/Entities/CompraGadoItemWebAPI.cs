using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCompraGado.Services.Models.Entities
{
    public class CompraGadoItemWebAPI
    {
        public string Quantidade { get; set; }
        public long CompraGadoID { get; set; }
        public long AnimalID { get; set; }
    }
}
