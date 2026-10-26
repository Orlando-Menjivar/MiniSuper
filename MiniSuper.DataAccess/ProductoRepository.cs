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

        public Producto Select(int productoId)
        {
            Producto entity = null;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpProductoSelect", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductoId", productoId);
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (rd.Read())
                        {
                            entity = new Producto
                            {
                                ProductoId = rd.GetInt32(0),
                                CodigoBarra = rd.GetString(1),
                                NombreProducto = rd.GetString(2),
                                UnidadMedida = rd.GetString(3),
                                PrecioVenta = rd.GetDecimal(4),
                                EstadoProductoId = rd.GetInt32(5),
                                CategoriaId = rd.GetInt32(6)
                            };
                        }
                    }
                }
            }
            return entity;
        }

        public int Insert(Producto entity)
        {
            int result = 0;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpProductoInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CodigoBarra", entity.CodigoBarra);
                    cmd.Parameters.AddWithValue("@NombreProducto", entity.NombreProducto);
                    cmd.Parameters.AddWithValue("@UnidadMedida", entity.UnidadMedida);
                    cmd.Parameters.AddWithValue("@PrecioVenta", entity.PrecioVenta);
                    cmd.Parameters.AddWithValue("@EstadoProductoId", entity.EstadoProductoId);
                    cmd.Parameters.AddWithValue("@CategoriaId", entity.CategoriaId);
                    conn.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return result;
        }

        public int Update(Producto entity)
        {
            int result = 0;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpProductoUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductoId", entity.ProductoId);
                    cmd.Parameters.AddWithValue("@CodigoBarra", entity.CodigoBarra);
                    cmd.Parameters.AddWithValue("@NombreProducto", entity.NombreProducto);
                    cmd.Parameters.AddWithValue("@UnidadMedida", entity.UnidadMedida);
                    cmd.Parameters.AddWithValue("@PrecioVenta", entity.PrecioVenta);
                    cmd.Parameters.AddWithValue("@EstadoProductoId", entity.EstadoProductoId);
                    cmd.Parameters.AddWithValue("@CategoriaId", entity.CategoriaId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        public int Delete(int productoId)
        {
            int result = 0;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpProductoDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductoId", productoId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }
    }
}
