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
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

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
    }
}

