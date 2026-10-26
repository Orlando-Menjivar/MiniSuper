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
    public class UsuarioRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public UsuarioRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Usuario> SelectAll()
        {
            List<Usuario> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpUsuarioSelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<Usuario>();

                        while (rd.Read())
                        {
                            Usuario entity = new Usuario
                            {
                                UsuarioId = rd.GetInt32(0),
                                NombreUsuario = rd.GetString(1),
                                Clave = rd.GetString(2),
                                FechaCreacion = rd.GetDateTime(3),
                                RolId = rd.GetInt32(4),
                                EmpleadoId = rd.GetInt32(5),
                                EstadoUsuarioId = rd.GetInt32(6)
                            };
                            result.Add(entity);
                        }

                    }
                }

            }
            return result;
        }

        public Usuario Select(int usuarioId)
        {
            Usuario entity = null;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpUsuarioSelect", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (rd.Read())
                        {
                            entity = new Usuario
                            {
                                UsuarioId = rd.GetInt32(0),
                                NombreUsuario = rd.GetString(1),
                                Clave = rd.GetString(2),
                                FechaCreacion = rd.GetDateTime(3),
                                RolId = rd.GetInt32(4),
                                EmpleadoId = rd.GetInt32(5),
                                EstadoUsuarioId = rd.GetInt32(6)
                            };
                        }
                    }
                }
            }
            return entity;
        }

        public int Insert(Usuario entity)
        {
            int result = 0;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpUsuarioInsert", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreUsuario", entity.NombreUsuario);
                    cmd.Parameters.AddWithValue("@Clave", entity.Clave);
                    cmd.Parameters.AddWithValue("@FechaCreacion", entity.FechaCreacion);
                    cmd.Parameters.AddWithValue("@RolId", entity.RolId);
                    cmd.Parameters.AddWithValue("@EmpleadoId", entity.EmpleadoId);
                    cmd.Parameters.AddWithValue("@EstadoUsuarioId", entity.EstadoUsuarioId);
                    conn.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return result;
        }

        public int Update(Usuario entity)
        {
            int result = 0;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpUsuarioUpdate", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioId", entity.UsuarioId);
                    cmd.Parameters.AddWithValue("@NombreUsuario", entity.NombreUsuario);
                    cmd.Parameters.AddWithValue("@Clave", entity.Clave);
                    cmd.Parameters.AddWithValue("@FechaCreacion", entity.FechaCreacion);
                    cmd.Parameters.AddWithValue("@RolId", entity.RolId);
                    cmd.Parameters.AddWithValue("@EmpleadoId", entity.EmpleadoId);
                    cmd.Parameters.AddWithValue("@EstadoUsuarioId", entity.EstadoUsuarioId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        public int Delete(int usuarioId)
        {
            int result = 0;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpUsuarioDelete", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }
    }
}
