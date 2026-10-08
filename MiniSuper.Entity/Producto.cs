using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSuper.Entity
{
    public class Producto
    {

        public int ProductoId { get; set; }
        public string CodigoBarra { get; set; }
        public string NombreProducto { get; set; }
        public string UnidadMedida { get; set; }
        public decimal PrecioVenta { get; set; }
        public int EstadoProductoId { get; set; }
        public int CategoriaId { get; set; }
    }
}
