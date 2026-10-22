using MiniSuper.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSuper.DataAccess
{
    public class ProveedorRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public ProveedorRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Proveedor> SelectAll()
        {
            List<Proveedor> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpProveedorSelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<Proveedor>();

                        while (rd.Read())
                        {
                            Proveedor entity = new Proveedor
                            {
                                ProveedorId = rd.GetInt32(0),
                                NombreEmpresa = rd.GetString(1),
                                NombreProveedor = rd.GetString(2),
                                ApellidoProveedor = rd.GetString(3),
                                TipoProveedor = rd.GetString(4),
                                DUI = rd.GetString(5),
                            };
                            result.Add(entity);
                        }

                    }
                }


            }
            return result;
        }
    }
}
