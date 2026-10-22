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
    public class PagoRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public PagoRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;


        }
        public List<Pago> SelectAll()
        {
            List<Pago> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpPagoSelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<Pago>();

                        while (rd.Read())
                        {
                            Pago entity = new Pago
                            {
                                PagoId = rd.GetInt32(0),
                                VentaId = rd.GetInt32(1),
                                FormaPagoId = rd.GetInt32(2),
                                Monto = rd.GetDecimal(3),
                                MontoRecibido = rd.GetDecimal(4),
                                Cambio = rd.GetDecimal(5),
                                DuiTitular = rd.GetString(6),
                                FirmaTitular = rd.GetString(7)

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
