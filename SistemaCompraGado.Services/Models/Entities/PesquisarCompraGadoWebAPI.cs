using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCompraGado.Services.Models.Entities
{
    public class PesquisarCompraGadoWebAPI
    {
        public class PesquisarCompraGado
        {
            public long ID { get; set; }
            public DateTime DataEntrega { get; set; }
            public long PecuaristaID { get; set; }
            public DateTime Ate { get; set; }
        }
    }
}
