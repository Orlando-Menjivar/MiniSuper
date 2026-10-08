using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSuper.Entity
{
    public class Compra

    {
        public int CompraId { get; set; }
        public string NombreFactura { get; set; }

        public DateTime FechaHora { get; set; }
        public int DetalleVentaId { get; set; }
        public int UsuarioId { get; set; }
    }
}
