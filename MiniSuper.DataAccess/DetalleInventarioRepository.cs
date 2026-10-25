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
    public class DetalleInventarioRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public DetalleInventarioRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<DetalleInventario> SelectAll()
        {
            List<DetalleInventario> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpDetalleInventarioSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<DetalleInventario>();

                        while (rd.Read())
                        {
                            DetalleInventario entity = new DetalleInventario
                            {
                                DetalleInventarioId = rd.GetInt32(0),
                                InventarioId = rd.GetInt32(1),
                                LoteInventarioId = rd.GetInt32(2),
                                FechaHoraMovimiento = rd.GetDateTime(3),
                                TipoMovimiento = rd.GetString(4),
                                Cantidad = rd.GetInt32(5),
                                Observacion = rd.GetString(6),
                                DetVentaId = rd.IsDBNull(7) ? (int?)null : rd.GetInt32(7)
                            };
                            result.Add(entity);
                        }
                    }
                }
            }
            return result;
        }

        public DetalleInventario Select(int detalleInventarioId)
        {
            DetalleInventario entity = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpDetalleInventarioSelect", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DetalleInventarioId", detalleInventarioId);

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (rd.Read())
                        {
                            entity = new DetalleInventario
                            {
                                DetalleInventarioId = rd.GetInt32(0),
                                InventarioId = rd.GetInt32(1),
                                LoteInventarioId = rd.GetInt32(2),
                                FechaHoraMovimiento = rd.GetDateTime(3),
                                TipoMovimiento = rd.GetString(4),
                                Cantidad = rd.GetInt32(5),
                                Observacion = rd.GetString(6),
                                DetVentaId = rd.IsDBNull(7) ? (int?)null : rd.GetInt32(7)
                            };
                        }
                    }
                }
            }
            return entity;
        }

        public int Insert(DetalleInventario entity)
        {
            int result = 0;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpDetalleInventarioInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InventarioId", entity.InventarioId);
                    cmd.Parameters.AddWithValue("@LoteInventarioId", entity.LoteInventarioId);
                    cmd.Parameters.AddWithValue("@FechaHoraMovimiento", entity.FechaHoraMovimiento);
                    cmd.Parameters.AddWithValue("@TipoMovimiento", entity.TipoMovimiento);
                    cmd.Parameters.AddWithValue("@Cantidad", entity.Cantidad);
                    cmd.Parameters.AddWithValue("@Observacion", entity.Observacion);
                    cmd.Parameters.AddWithValue("@DetVentaId", (object)entity.DetVentaId ?? DBNull.Value);

                    conn.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return result;
        }
    }
}