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
    public class RolRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public RolRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;


        }


        public List<Rol> SelectAll()
        {
            List<Rol> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpRolSelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<Rol>();

                        while (rd.Read())
                        {
                            Rol entity = new Rol
                            {
                                RolId = rd.GetInt32(0),
                                TipoRol= rd.GetString(1),
                                descripcion = rd.GetString(2)
                            };
                            result.Add(entity);
                        }
                    }
                }
            }
            return result;
        }

        public Rol Select(int rolId)
        {
            Rol entity = null;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpRolSelect", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RolId", rolId);
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (rd.Read())
                        {
                            entity = new Rol
                            {
                                RolId = rd.GetInt32(0),
                                TipoRol = rd.GetString(1),
                                descripcion = rd.GetString(2)
                            };
                        }
                    }
                }
            }
            return entity;
        }

        public int Insert(Rol entity)
        {
            int result = 0;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpRolInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TipoRol", entity.TipoRol);
                    cmd.Parameters.AddWithValue("@descripcion", entity.descripcion);
                    conn.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
                    
            }
            return result;
        }

        public int Update(Rol entity)
        {
            int result = 0;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpRolUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RolId", entity.RolId);
                    cmd.Parameters.AddWithValue("@TipoRol", entity.TipoRol);
                    cmd.Parameters.AddWithValue("@descripcion", entity.descripcion);
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        public int Delete(int rolId)
        {
            int result = 0;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpRolDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RolId", rolId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }
    }
}

