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
    public class InventarioRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public InventarioRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;


        }
        public List<Inventario> SelectAll()
        {
            List<Inventario> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpInventarioSelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<Inventario>();

                        while (rd.Read())
                        {
                            Inventario entity = new Inventario
                            {
                                InventarioId = rd.GetInt32(0),
                                ProductoId = rd.GetInt32(1),
                                StockActual = rd.GetInt32(2),
                                StockMinimo = rd.GetInt32(3),
                                CostoPromedio = rd.GetDecimal(4)

                            
                            };
                            result.Add(entity);
                        }
                    }
                }
            }
            return result;
        }

        public Inventario Select(int inventarioId)
        {
            Inventario entity = null;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpInventarioSelect", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InventarioId", inventarioId);
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (rd.Read())
                        {
                            entity = new Inventario
                            {
                                InventarioId = rd.GetInt32(0),
                                ProductoId = rd.GetInt32(1),
                                StockActual = rd.GetInt32(2),
                                StockMinimo = rd.GetInt32(3),
                                CostoPromedio = rd.GetDecimal(4)
                            };
                        }
                    }
                }
            }
            return entity;
        }

        public int Insert(Inventario entity)
        {
            int result = 0;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpInventarioInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductoId", entity.ProductoId);
                    cmd.Parameters.AddWithValue("@StockActual", entity.StockActual);
                    cmd.Parameters.AddWithValue("@StockMinimo", entity.StockMinimo);
                    cmd.Parameters.AddWithValue("@CostoPromedio", entity.CostoPromedio);
                    conn.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return result;
        }

    }
}

