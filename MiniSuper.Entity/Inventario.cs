using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSuper.Entity
{
    public class Inventario
    {
        public int InventarioId { get; set; }
        public int ProductoId { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public decimal CostoPromedio { get; set; }

    }
}
