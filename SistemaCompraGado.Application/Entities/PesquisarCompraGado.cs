using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompraGado.Application.Entities
{
    public class PesquisarCompraGado
    {
        public long ID { get; set; }
        public DateTime DataEntrega { get; set; }
        public long PecuaristaID { get; set; }
        public string NomePecuarista { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
