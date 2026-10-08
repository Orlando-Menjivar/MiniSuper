using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSuper.Entity
{
    public class DetalleVenta
    {
        public int DetVentaId { get; set; }
        public int VentaId { get; set; }
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get; set; }
    }
}
