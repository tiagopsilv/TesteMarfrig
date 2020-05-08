using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCompraGado.Presentation.Negocios.Entities
{
    public class CompraGadoItemPrint
    {
        public long ID { get; set; }
        public DateTime DataEmtrega { get; set; }
        public string NomePecuarista { get; set; }
        public string DescricaoAnimal { get; set; }
        public long Quantidade { get; set; }
        public decimal Preco { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
