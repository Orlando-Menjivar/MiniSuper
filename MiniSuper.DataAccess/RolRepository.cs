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
    }
}

