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
    public class DetalleVentaRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public DetalleVentaRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<DetalleVenta> SelectAll()
        {
            List<DetalleVenta> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpDetalleVentaSelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<DetalleVenta>();

                        while (rd.Read())
                        {
                            DetalleVenta entity = new DetalleVenta
                            {
                                DetVentaId = rd.GetInt32(0),
                                VentaId = rd.GetInt32(1),
                                Cantidad = rd.GetInt32(2),
                                ProductoId = rd.GetInt32(3),
                                Precio = rd.GetDecimal(4),
                                Subtotal = rd.GetDecimal(5)
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
