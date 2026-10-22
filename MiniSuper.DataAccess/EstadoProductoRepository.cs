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
    public class EstadoProductoRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public EstadoProductoRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<EstadoProducto> SelectAll()
        {
            List<EstadoProducto> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpEstadoProductoSelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<EstadoProducto>();

                        while (rd.Read())
                        {
                            EstadoProducto entity = new EstadoProducto
                            {
                                EstadoProductoId = rd.GetInt32(0),
                                TipoEstado = rd.GetString(1)
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
