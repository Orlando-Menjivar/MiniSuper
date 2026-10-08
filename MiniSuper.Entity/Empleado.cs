using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSuper.Entity
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string PrimerNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoNombre { get; set; }
        public string SegundoApellido { get; set; }
        public string DUI { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int CargoId { get; set; }
    }
}
