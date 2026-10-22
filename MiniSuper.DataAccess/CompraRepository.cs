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
    public class CompraRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public CompraRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Compra> SelectAll()
        {
            List<Compra> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpCompraSelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<Compra>();

                        while (rd.Read())
                        {
                            Compra entity = new Compra
                            {
                                CompraId = rd.GetInt32(0),
                                NombreFactura = rd.GetString(1),
                                FechaHora = rd.GetDateTime(2),
                                DetalleVentaId = rd.GetInt32(3),
                                UsuarioId = rd.GetInt32(4)
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
