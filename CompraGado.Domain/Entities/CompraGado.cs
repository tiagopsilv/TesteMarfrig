using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompraGado.Domain.Entities
{
    public class CompraGado
    {
        public long ID { get; set; }
        public DateTime DataEntrega { get; set; }
        public long PecuaristaID { get; set; }
        public Pecuarista Pecuarisa { get; set; }
        public List<CompraGadoItem> CompraDadoItem { get; set; }
    }
}
