using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCompraGado.Presentation.Negocios.Entities
{
    public class PesquisarCompraGado
    {
        public long ID { get; set; }
        public DateTime DataEntrega { get; set; }
        public long PecuaristaID { get; set; }
        public string NomePecuarista { get; set; }
        public decimal ValorTotal { get; set; }
        public long Count { get; set; }
    }
}
