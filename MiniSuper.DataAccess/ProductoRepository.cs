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
    public class ProductoRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public ProductoRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Producto> SelectAll()
        {
            List<Producto> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpProductoSelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<Producto>();

                        while (rd.Read())
                        {
                            Producto entity = new Producto
                            {
                                ProductoId = rd.GetInt32(0),
                                CodigoBarra = rd.GetString(1),
                                NombreProducto = rd.GetString(2),
                                UnidadMedida = rd.GetString(3),
                                PrecioVenta = rd.GetDecimal(4),
                                EstadoProductoId = rd.GetInt32(5),
                                CategoriaId = rd.GetInt32(6)
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
