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
    public class DetalleCompraRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        public DetalleCompraRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public List<DetalleCompra> SelectAll()
        {
            List<DetalleCompra> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpDetalleCompraSelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<DetalleCompra>();

                        while (rd.Read())
                        {
                            DetalleCompra entity = new DetalleCompra
                            {
                                DetalleCompraId = rd.GetInt32(0),
                                Total = rd.GetDecimal(1),
                                Cantidad = rd.GetInt32(2),
                                CompraId= rd.GetInt32(3),
                                ProveedorId = rd.GetInt32(4),
                                UsuarioId = rd.GetInt32(5)
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
