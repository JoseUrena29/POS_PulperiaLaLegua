using CapaEntidad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CapaDatos_Negocio
    {
        public Negocio ObtenerDatos()
        {
            Negocio obj = new Negocio();

            try
            {
                using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
                {
                    objconexion.Open();

                    string query = "Select IdNegocio,Nombre,NumeroIdentificacion,Direccion from NEGOCIO where IdNegocio = 2";

                    SqlCommand comm = new SqlCommand(query, objconexion);
                    comm.CommandType = CommandType.Text;

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Negocio()
                            {
                                IdNegocio = int.Parse(dr["IdNegocio"].ToString()),
                                Nombre = dr["Nombre"].ToString(),
                                NumeroIdentificacion = dr["NumeroIdentificacion"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                            };
                        }
                    }
                }
            }
            catch
            {
                obj = new Negocio();

            }
            return obj;
        }

        public bool GuardarDatos(Negocio objeto, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            try
            {
                using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
                {
                    objconexion.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Update NEGOCIO set Nombre = @Nombre,");
                    query.AppendLine("NumeroIdentificacion = @NumeroIdentificacion,");
                    query.AppendLine("Direccion = @Direccion");
                    query.AppendLine("where IdNegocio = 2;");

                    SqlCommand comm = new SqlCommand(query.ToString(), objconexion);
                    comm.Parameters.AddWithValue("@Nombre", objeto.Nombre);
                    comm.Parameters.AddWithValue("@NumeroIdentificacion", objeto.NumeroIdentificacion);
                    comm.Parameters.AddWithValue("@Direccion", objeto.Direccion);
                    comm.CommandType = CommandType.Text;

                    if (comm.ExecuteNonQuery() < 1)
                    {
                        mensaje = "Error al guardar los datos";
                        respuesta = false;
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                respuesta = false;
                return respuesta;
            }
            return respuesta;
        }

        public byte[] ObtenerLogo(out bool obtenido)
        {
            obtenido = true;
            byte[] LogoBytes = new byte[0];

            try
            {
                using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
                {
                    objconexion.Open();
                    string query = "Select Logo from NEGOCIO where IdNegocio = 2";

                    SqlCommand comm = new SqlCommand(query, objconexion);
                    comm.CommandType = CommandType.Text;

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LogoBytes = (byte[])dr["Logo"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                {
                    obtenido = false;
                    LogoBytes = new byte[0];
                }

            }
            return LogoBytes;
        }

        public bool ActualizarLogo(byte[] imagen, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            try
            {
                using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
                {
                    objconexion.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Update NEGOCIO set Logo = @imagen");
                    query.AppendLine("where IdNegocio = 2;");

                    SqlCommand comm = new SqlCommand(query.ToString(), objconexion);
                    comm.Parameters.AddWithValue("@imagen", imagen);
                    comm.CommandType = CommandType.Text;

                    if (comm.ExecuteNonQuery() < 1)
                    {
                        mensaje = "Error al actualizar el logo";
                        respuesta = false;
                    }
                }
            }
            catch (Exception ex)
            {
                    mensaje = ex.Message;
                    respuesta = false;
                    return respuesta;
            }
            return respuesta;
        }
    }
}
