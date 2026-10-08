using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSuper.Entity
{
    public class PAGO
    {
        public int PagoId { get; set; }
        public int VentaId { get; set; }
        public int FormaPagoId { get; set; }
        public decimal Monto { get; set; }
        public decimal MontoRecibido { get; set; }
        public decimal Cambio { get; set; }
        public string DuiTitular { get; set; }
        public string FirmaTitular { get; set; }
    }
}
