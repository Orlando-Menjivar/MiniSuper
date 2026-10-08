using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSuper.Entity
{
    public class Venta
    {
        public int VentaId { get; set; }
        public DateTime FechaHora { get; set; }
        public int NumeroTicket { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public decimal IVA { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    }
}
