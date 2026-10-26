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
    public class FormaPagoRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public FormaPagoRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;


        }
        public List<FormaPago> SelectAll()
        {
            List<FormaPago> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpFormaPagoSelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<FormaPago>();

                        while (rd.Read())
                        {
                            FormaPago entity = new FormaPago
                            {
                                FormaPagoId = rd.GetInt32(0),
                                TipoPago = rd.GetString(1)

                            };
                            result.Add(entity);
                        }
                    }
                }
            }
            return result;
        }

        public FormaPago Select(int formaPagoId)
        {
            FormaPago entity = null;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpFormaPagoSelect", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FormaPagoId", formaPagoId);
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (rd.Read())
                        {
                            entity = new FormaPago
                            {
                                FormaPagoId = rd.GetInt32(0),
                                TipoPago = rd.GetString(1)
                            };
                        }
                    }
                }
            }
            return entity;
        }

        public int Insert(FormaPago entity)
        {
            int result = 0;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpFormaPagoInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TipoPago", entity.TipoPago);
                    conn.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return result;
        }

        public int Update(FormaPago entity)
        {
            int result = 0;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpFormaPagoUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FormaPagoId", entity.FormaPagoId);
                    cmd.Parameters.AddWithValue("@TipoPago", entity.TipoPago);
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        public int Delete(int formaPagoId)
        {
            int result = 0;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpFormaPagoDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FormaPagoId", formaPagoId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

    }
}
