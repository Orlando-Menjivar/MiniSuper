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
    public class LoteInventarioRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        public LoteInventarioRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }


        public List<LoteInventario> SelectAll()
        {
            List<LoteInventario> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpLoteInventarioSelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<LoteInventario>();

                        while (rd.Read())
                        {
                            LoteInventario entity = new LoteInventario
                            {
                                LoteInventarioId = rd.GetInt32(0),
                                DetCompraId = rd.GetInt32(1),
                                FechaIngreso = rd.GetDateTime(2),
                                StockInicialLote = rd.GetInt32(3),
                                StockActualLote = rd.GetInt32(4)
                            };
                            result.Add(entity);
                        }
                    }
                }
            }
            return result;
        }

        public LoteInventario Select(int loteInventarioId)
        {
            LoteInventario entity = null;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpLoteInventarioSelect", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LoteInventarioId", loteInventarioId);
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (rd.Read())
                        {
                            entity = new LoteInventario
                            {
                                LoteInventarioId = rd.GetInt32(0),
                                DetCompraId = rd.GetInt32(1),
                                FechaIngreso = rd.GetDateTime(2),
                                StockInicialLote = rd.GetInt32(3),
                                StockActualLote = rd.GetInt32(4)
                            };
                        }
                    }
                }
            }
            return entity;
        }

        public int Insert(LoteInventario entity)
        {
            int result = 0;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpLoteInventarioInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DetCompraId", entity.DetCompraId);
                    cmd.Parameters.AddWithValue("@FechaIngreso", entity.FechaIngreso);
                    cmd.Parameters.AddWithValue("@StockInicialLote", entity.StockInicialLote);
                    cmd.Parameters.AddWithValue("@StockActualLote", entity.StockActualLote);

                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

    }
}
