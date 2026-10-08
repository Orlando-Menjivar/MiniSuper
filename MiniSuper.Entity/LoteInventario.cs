using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSuper.Entity
{
    public class LoteInventario
    {
        public int LoteInventarioId { get; set; }
        public int DetCompraId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int StockInicialLote { get; set; }
        public int StockActualLote { get; set; }
    }
}
