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
    public class CargoRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public CargoRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Cargo> SelectAll()
        {
            List<Cargo> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpCargoSelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<Cargo>();

                        while (rd.Read())
                        {
                            Cargo entity = new Cargo
                            {
                                CargoId = rd.GetInt32(0),
                                NombreCargo = rd.GetString(1)
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

                              