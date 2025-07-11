using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CapaDatos_Proveedor
    {
        //Método para mostrar la lista de Proveedores
        public List<Proveedor> Listar()
        {
            List<Proveedor> lista = new List<Proveedor>();

            using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select IdProveedor,NumeroIdentidad,NombreComercial,Correo,Telefono,Direccion,Estado from PROVEEDOR");
                    SqlCommand comm = new SqlCommand(query.ToString(), objconexion);
                    comm.CommandType = CommandType.Text;

                    objconexion.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Proveedor()
                            {
                                IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                                NumeroIdentidad = dr["NumeroIdentidad"].ToString(),
                                NombreComercial = dr["NombreComercial"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Proveedor>();
                }
            }
            return lista;
        }


        //Método para crear nuevos Proveedores
        public int Registrar(Proveedor obj, out string Mensaje)
        {
            int IdProveedor_Generado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand comm = new SqlCommand("SP_RegistrarProveedor", objconexion);
                    comm.Parameters.AddWithValue("NumeroIdentidad", obj.NumeroIdentidad);
                    comm.Parameters.AddWithValue("NombreComercial", obj.NombreComercial);
                    comm.Parameters.AddWithValue("Correo", obj.Correo);
                    comm.Parameters.AddWithValue("Telefono", obj.Telefono);
                    comm.Parameters.AddWithValue("Direccion", obj.Direccion);
                    comm.Parameters.AddWithValue("Estado", obj.Estado);
                    comm.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    comm.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    comm.CommandType = CommandType.StoredProcedure;

                    objconexion.Open();

                    comm.ExecuteNonQuery();

                    IdProveedor_Generado = Convert.ToInt32(comm.Parameters["Resultado"].Value);
                    Mensaje = comm.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                IdProveedor_Generado = 0;
                Mensaje = ex.Message;
            }
            return IdProveedor_Generado;
        }

        //Método para crear editar Proveedores
        public bool Editar(Proveedor obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand comm = new SqlCommand("SP_EditarProveedor", objconexion);
                    comm.Parameters.AddWithValue("IdProveedor", obj.IdProveedor);
                    comm.Parameters.AddWithValue("NumeroIdentidad", obj.NumeroIdentidad);
                    comm.Parameters.AddWithValue("NombreComercial", obj.NombreComercial);
                    comm.Parameters.AddWithValue("Correo", obj.Correo);
                    comm.Parameters.AddWithValue("Telefono", obj.Telefono);
                    comm.Parameters.AddWithValue("Direccion", obj.Direccion);
                    comm.Parameters.AddWithValue("Estado", obj.Estado);
                    comm.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    comm.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    comm.CommandType = CommandType.StoredProcedure;

                    objconexion.Open();

                    comm.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(comm.Parameters["Resultado"].Value);
                    Mensaje = comm.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }
    }
}
