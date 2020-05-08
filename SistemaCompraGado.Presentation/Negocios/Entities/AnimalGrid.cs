using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCompraGado.Presentation.Negocios.Entities
{
    public class AnimalGrid
    {
        public int IDGrid { get; set; }
        public string DescricaoAnimal { get; set; }
        public string Quantidade { get; set; }
        public string Preco { get; set; }
        public string ValorTotal { get; set; }
        public CompraGadoItem Itens { get; set; }
        public int IndexCombo { get; set; }
    }
}
