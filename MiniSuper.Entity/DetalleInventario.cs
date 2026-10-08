using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSuper.Entity
{
    public class DetalleInventario
    {
        public int DetalleInventarioId { get; set; }
        public int InventarioId { get; set; }
        public int LoteInventarioId { get; set; }
        public DateTime FechaHoraMovimiento { get; set; }
        public string TipoMovimiento { get; set; }
        public int Cantidad { get; set; }
        public string Observacion { get; set; }
        public int? DetVentaId { get; set; }
    }
}
