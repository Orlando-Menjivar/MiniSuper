using System;
using MiniSuper.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MiniSuper.DataAccess
{
    public class EmpleadoRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public EmpleadoRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Empleado> SelectAll()
        {
            List<Empleado> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpEmpleadoSelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<Empleado>();

                        while (rd.Read())
                        {
                            Empleado entity = new Empleado
                            {
                                EmpleadoId = rd.GetInt32(0),
                                PrimerNombre = rd.GetString(1),
                                SegundoNombre = rd.GetString(2),
                                PrimerApellido = rd.GetString(3),
                                SegundoApellido = rd.GetString(4),
                                DUI = rd.GetString(5),
                                Telefono = rd.GetString(6),
                                Correo = rd.GetString(7),
                                Direccion = rd.GetString(8),
                                CargoId = rd.GetInt32(9)
                            };
                            result.Add(entity);
                        }

                    }
                }

            } return result;
        }
        
    }
}
