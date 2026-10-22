using System;
using MiniSuper.Entity;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSuper.DataAccess
{
    public class CategoriaRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public CategoriaRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Categoria> SelectAll()
        {
            List<Categoria> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpCategoriaSelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<Categoria>();

                        while (rd.Read())
                        {
                            Categoria entity = new Categoria
                            {
                                CategoriaId = rd.GetInt32(0),
                                NombreCategoria = rd.GetString(1)
                            };
                            result.Add(entity);
                        }

                    }
                }


            }
            return result;
        }

        public int Insert(Categoria entity)
        {
            int result = 0;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpCategoriaInsert", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreCategoria", entity.NombreCategoria);
                    conn.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return result;
        }
    }
}
