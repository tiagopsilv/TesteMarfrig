using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCompraGado.Presentation.Negocios.Entities
{
    public class CompraGadoRep
    {
            public long ID { get; set; }
            public DateTime DataEntrega { get; set; }
            public long PecuaristaID { get; set; }
            public List<CompraGadoItem> CompraDadoItem { get; set; }
    }
}
