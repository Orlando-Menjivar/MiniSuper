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
                    cmd.CommandType = CommandType.StoredProcedure;

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

        public DetalleVenta Select(int detVentaId)
        {
            DetalleVenta entity = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpDetalleVentaSelect", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DetVentaId", detVentaId);

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (rd.Read())
                        {
                            entity = new DetalleVenta
                            {
                                DetVentaId = rd.GetInt32(0),
                                VentaId = rd.GetInt32(1),
                                Cantidad = rd.GetInt32(2),
                                ProductoId = rd.GetInt32(3),
                                Precio = rd.GetDecimal(4),
                                Subtotal = rd.GetDecimal(5)
                            };
                        }
                    }
                }
            }
            return entity;
        }

        public int Insert(DetalleVenta entity)
        {
            int result = 0;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpDetalleVentaInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VentaId", entity.VentaId);
                    cmd.Parameters.AddWithValue("@Cantidad", entity.Cantidad);
                    cmd.Parameters.AddWithValue("@ProductoId", entity.ProductoId);
                    cmd.Parameters.AddWithValue("@Precio", entity.Precio);
                    cmd.Parameters.AddWithValue("@Subtotal", entity.Subtotal);

                    conn.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return result;
        }
    }
}