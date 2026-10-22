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

    }
}
