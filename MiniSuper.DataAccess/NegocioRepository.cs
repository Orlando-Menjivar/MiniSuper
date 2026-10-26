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
    public class NegocioRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public NegocioRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;


        }
        public List<Negocio> SelectAll()
        {
            List<Negocio> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpNegocioSelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<Negocio>();

                        while (rd.Read())
                        {
                            Negocio entity = new Negocio
                            {
                                NegocioId = rd.GetInt32(0),
                                NombreNegocio = rd.GetString(1),
                                Dirreccion = rd.GetString(2),
                                Telefono = rd.GetString(3),
                                MensajeTicket = rd.GetString(4)
                            };
                            result.Add(entity);
                        }
                    }
                }
            }
            return result;
        }

        public Negocio Select(int negocioId)
        {
            Negocio entity = null;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpNegocioSelect", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NegocioId", negocioId);
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (rd.Read())
                        {
                            entity = new Negocio
                            {
                                NegocioId = rd.GetInt32(0),
                                NombreNegocio = rd.GetString(1),
                                Dirreccion = rd.GetString(2),
                                Telefono = rd.GetString(3),
                                MensajeTicket = rd.GetString(4)
                            };
                        }
                    }
                }
            }
            return entity;
        }

        public int Insert(Negocio entity)
        {
            int result = 0;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpNegocioInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreNegocio", entity.NombreNegocio);
                    cmd.Parameters.AddWithValue("@Dirreccion", entity.Dirreccion);
                    cmd.Parameters.AddWithValue("@Telefono", entity.Telefono);
                    cmd.Parameters.AddWithValue("@MensajeTicket", entity.MensajeTicket);
                    conn.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return result;

        }

        public int Update(Negocio entity)
        {
            int result = 0;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpNegocioUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NegocioId", entity.NegocioId);
                    cmd.Parameters.AddWithValue("@NombreNegocio", entity.NombreNegocio);
                    cmd.Parameters.AddWithValue("@Dirreccion", entity.Dirreccion);
                    cmd.Parameters.AddWithValue("@Telefono", entity.Telefono);
                    cmd.Parameters.AddWithValue("@MensajeTicket", entity.MensajeTicket);
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        public int Delete(int negocioId)
        {
            int result = 0;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpNegocioDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NegocioId", negocioId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;

        }
    }
}

