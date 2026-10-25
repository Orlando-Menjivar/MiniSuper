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
    public class EmpleadoRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public EmpleadoRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Empleado> SelectAll()
        {
            List<Empleado> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpEmpleadoSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<Empleado>();

                        while (rd.Read())
                        {
                            Empleado entity = new Empleado
                            {
                                EmpleadoId = rd.GetInt32(0),
                                PrimerNombre = rd.GetString(1),
                                SegundoNombre = rd.GetString(2),
                                PrimerApellido = rd.GetString(3),
                                SegundoApellido = rd.GetString(4),
                                DUI = rd.GetString(5),
                                Telefono = rd.GetString(6),
                                Correo = rd.GetString(7),
                                Direccion = rd.GetString(8),
                                CargoId = rd.GetInt32(9)
                            };
                            result.Add(entity);
                        }
                    }
                }
            }
            return result;
        }

        public Empleado Select(int empleadoId)
        {
            Empleado entity = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpEmpleadoSelect", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpleadoId", empleadoId);

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (rd.Read())
                        {
                            entity = new Empleado
                            {
                                EmpleadoId = rd.GetInt32(0),
                                PrimerNombre = rd.GetString(1),
                                SegundoNombre = rd.GetString(2),
                                PrimerApellido = rd.GetString(3),
                                SegundoApellido = rd.GetString(4),
                                DUI = rd.GetString(5),
                                Telefono = rd.GetString(6),
                                Correo = rd.GetString(7),
                                Direccion = rd.GetString(8),
                                CargoId = rd.GetInt32(9)
                            };
                        }
                    }
                }
            }
            return entity;
        }

        public int Insert(Empleado entity)
        {
            int result = 0;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpEmpleadoInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PrimerNombre", entity.PrimerNombre);
                    cmd.Parameters.AddWithValue("@SegundoNombre", entity.SegundoNombre);
                    cmd.Parameters.AddWithValue("@PrimerApellido", entity.PrimerApellido);
                    cmd.Parameters.AddWithValue("@SegundoApellido", entity.SegundoApellido);
                    cmd.Parameters.AddWithValue("@DUI", entity.DUI);
                    cmd.Parameters.AddWithValue("@Telefono", entity.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", entity.Correo);
                    cmd.Parameters.AddWithValue("@Direccion", entity.Direccion);
                    cmd.Parameters.AddWithValue("@CargoId", entity.CargoId);

                    conn.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return result;
        }

        public int Update(Empleado entity)
        {
            int result = 0;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpEmpleadoUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpleadoId", entity.EmpleadoId);
                    cmd.Parameters.AddWithValue("@PrimerNombre", entity.PrimerNombre);
                    cmd.Parameters.AddWithValue("@SegundoNombre", entity.SegundoNombre);
                    cmd.Parameters.AddWithValue("@PrimerApellido", entity.PrimerApellido);
                    cmd.Parameters.AddWithValue("@SegundoApellido", entity.SegundoApellido);
                    cmd.Parameters.AddWithValue("@DUI", entity.DUI);
                    cmd.Parameters.AddWithValue("@Telefono", entity.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", entity.Correo);
                    cmd.Parameters.AddWithValue("@Direccion", entity.Direccion);
                    cmd.Parameters.AddWithValue("@CargoId", entity.CargoId);

                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        public int Delete(int empleadoId)
        {
            int result = 0;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpEmpleadoDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpleadoId", empleadoId);

                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }
    }
}


