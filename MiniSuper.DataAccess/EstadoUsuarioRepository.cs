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
    public class EstadoUsuarioRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        public EstadoUsuarioRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public int Insert(EstadoUsuario entity)
        {
            throw new NotImplementedException();
        }

        public List<EstadoUsuario> SelectAll()
        {
            List<EstadoUsuario> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpEstadoUsuarioSelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<EstadoUsuario>();

                        while (rd.Read())
                        {
                            EstadoUsuario entity = new EstadoUsuario
                            {
                                EstadoUsuarioId = rd.GetInt32(0),
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