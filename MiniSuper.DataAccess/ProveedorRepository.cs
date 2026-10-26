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
    public class ProveedorRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public ProveedorRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Proveedor> SelectAll()
        {
            List<Proveedor> result = null;

            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpProveedorSelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        result = new List<Proveedor>();

                        while (rd.Read())
                        {
                            Proveedor entity = new Proveedor
                            {
                                ProveedorId = rd.GetInt32(0),
                                NombreEmpresa = rd.GetString(1),
                                NombreProveedor = rd.GetString(2),
                                ApellidoProveedor = rd.GetString(3),
                                TipoProveedor = rd.GetString(4),
                                DUI = rd.GetString(5),
                                Telefono = rd.GetString(6),
                                Correo = rd.GetString(7),
                                Direccion = rd.GetString(8)
                            };
                            result.Add(entity);
                        }

                    }
                }


            }
            return result;
        }

        public Proveedor Select(int proveedorId)
        {
            Proveedor entity = null;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpProveedorSelect", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProveedorId", proveedorId);
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (rd.Read())
                        {
                            entity = new Proveedor
                            {
                                ProveedorId = rd.GetInt32(0),
                                NombreEmpresa = rd.GetString(1),
                                NombreProveedor = rd.GetString(2),
                                ApellidoProveedor = rd.GetString(3),
                                TipoProveedor = rd.GetString(4),
                                DUI = rd.GetString(5),
                                Telefono = rd.GetString(6),
                                Correo = rd.GetString(7),
                                Direccion = rd.GetString(8)
                            };
                        }
                    }
                }
            }
            return entity;
        }

        public int Insert(Proveedor entity)
        {
            int result = 0;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpProveedorInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreEmpresa", entity.NombreEmpresa);
                    cmd.Parameters.AddWithValue("@NombreProveedor", entity.NombreProveedor);
                    cmd.Parameters.AddWithValue("@ApellidoProveedor", entity.ApellidoProveedor);
                    cmd.Parameters.AddWithValue("@TipoProveedor", entity.TipoProveedor);
                    cmd.Parameters.AddWithValue("@DUI", entity.DUI);
                    cmd.Parameters.AddWithValue("@Telefono", entity.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", entity.Correo);
                    cmd.Parameters.AddWithValue("@Direccion", entity.Direccion);
                    conn.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return result;
        }

        public int Update(Proveedor entity)
        {
            int result = 0;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpProveedorUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProveedorId", entity.ProveedorId);
                    cmd.Parameters.AddWithValue("@NombreEmpresa", entity.NombreEmpresa);
                    cmd.Parameters.AddWithValue("@NombreProveedor", entity.NombreProveedor);
                    cmd.Parameters.AddWithValue("@ApellidoProveedor", entity.ApellidoProveedor);
                    cmd.Parameters.AddWithValue("@TipoProveedor", entity.TipoProveedor);
                    cmd.Parameters.AddWithValue("@DUI", entity.DUI);
                    cmd.Parameters.AddWithValue("@Telefono", entity.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", entity.Correo);
                    cmd.Parameters.AddWithValue("@Direccion", entity.Direccion);
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        public int Delete(int proveedorId)
        {
            int result = 0;
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SpProveedorDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProveedorId", proveedorId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }
    }
}
