using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSuper.Entity
{
    public class DetalleCompra
    {
        public int DetalleCompraId { get; set; }
        public  decimal  Total { get; set; }
        public int Cantidad { get; set; }
        public  int CompraId   { get; set; }
        public int ProveedorId { get; set; }
        public  int  UsuarioId { get; set; }
        
    }
}
