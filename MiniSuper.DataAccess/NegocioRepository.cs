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
        
    }
}

