using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSuper.Entity
{
    public class Proveedor
    {

        public int ProveedorId { get; set; }

        public string NombreEmpresa { get; set; }
        public string NombreProveedor { get; set; }
        public string ApellidoProveedor { get; set; }
        public string TipoProveedor { get; set; }
        public string DUI { get; set; }
        public string Telefono { get; set; }
        public string correo { get; set; }
        public string Direccion { get; set; }
    }
}
