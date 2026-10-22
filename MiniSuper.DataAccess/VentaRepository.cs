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
    public class VentaRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public VentaRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Venta> SelectAll()
        {
            List<Venta> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpVentaSelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<Venta>();

                        while (rd.Read())
                        {
                            Venta entity = new Venta
                            {
                                VentaId = rd.GetInt32(0),
                                FechaHora = rd.GetDateTime(1),
                                NumeroTicket = rd.GetInt32(2),
                                UsuarioId = rd.GetInt32(3),
                                ClienteId = rd.GetInt32(4),
                                IVA = rd.GetDecimal(5),
                                Subtotal = rd.GetDecimal(6),
                                Total = rd.GetDecimal(7)
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
