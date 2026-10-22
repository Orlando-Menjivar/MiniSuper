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
    public class DetalleInventarioRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public DetalleInventarioRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;


        }
        public List<DetalleInventario> SelectAll()
        {
            List<DetalleInventario> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpDetalleInventarioSelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<DetalleInventario>();

                        while (rd.Read())
                        {
                            DetalleInventario entity = new DetalleInventario
                            {
                                DetalleInventarioId = rd.GetInt32(0),
                                InventarioId = rd.GetInt32(1),
                                LoteInventarioId = rd.GetInt32(2),
                                FechaHoraMovimiento = rd.GetDateTime(3),
                                TipoMovimiento = rd.GetString(4),
                                Cantidad = rd.GetInt32(5),
                                Observacion = rd.GetString(6),
                                DetVentaId = rd.IsDBNull(7) ? (int?)null : rd.GetInt32(7)

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
