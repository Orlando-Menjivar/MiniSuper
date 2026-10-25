
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
    public class ClienteRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public ClienteRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Cliente> SelectAll()
        {
            List<Cliente> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpClienteSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<Cliente>();

                        while (rd.Read())
                        {
                            Cliente entity = new Cliente
                            {
                                ClienteId = rd.GetInt32(0),
                                DUI = rd.GetString(1)
                            };
                            result.Add(entity);
                        }
                    }
                }
            }
            return result;
        }

        public Cliente Select(int clienteId)
        {
            Cliente entity = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpClienteSelect", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClienteId", clienteId);

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (rd.Read())
                        {
                            entity = new Cliente
                            {
                                ClienteId = rd.GetInt32(0),
                                DUI = rd.GetString(1)
                            };
                        }
                    }
                }
            }
            return entity;
        }

        public int Insert(Cliente entity)
        {
            int result = 0;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpClienteInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DUI", entity.DUI);
                    conn.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return result;
        }

        public int Update(Cliente entity)
        {
            int result = 0;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpClienteUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClienteId", entity.ClienteId);
                    cmd.Parameters.AddWithValue("@DUI", entity.DUI);
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        public int Delete(int clienteId)
        {
            int result = 0;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpClienteDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClienteId", clienteId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }
    }
}

