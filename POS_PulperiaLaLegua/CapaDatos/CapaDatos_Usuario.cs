using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CapaDatos_Usuario
    {
        //Método para mostrar la lista de Usuarios
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdUsuario,NumeroIdentidad,NombreCompleto,Correo,Telefono,UsuarioLogin,Clave,Estado from USUARIO");
                    SqlCommand comm = new SqlCommand(query.ToString(), objconexion);
                    comm.CommandType = CommandType.Text;

                    objconexion.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                NumeroIdentidad = dr["NumeroIdentidad"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Usuario>();
                }
            }
            return lista;
        }


        //Método para crear nuevos Usuarios
        /*public int Registrar(Usuario obj, out string Mensaje)
        {
            int IdUsuario_Generado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand comm = new SqlCommand("SP_RegistrarUsuario", objconexion);
                    comm.Parameters.AddWithValue("NumeroIdentidad", obj.NumeroIdentidad);
                    comm.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    comm.Parameters.AddWithValue("Correo", obj.Correo);
                    comm.Parameters.AddWithValue("Telefono", obj.Telefono);
                    comm.Parameters.AddWithValue("Estado", obj.Estado);
                    comm.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    comm.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    comm.CommandType = CommandType.StoredProcedure;

                    objconexion.Open();

                    comm.ExecuteNonQuery();

                    IdUsuario_Generado = Convert.ToInt32(comm.Parameters["Resultado"].Value);
                    Mensaje = comm.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                IdUsuario_Generado = 0;
                Mensaje = ex.Message;
            }
            return IdUsuario_Generado;
        }

        //Método para crear editar Usuarios
        public bool Editar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand comm = new SqlCommand("SP_EditarUsuario", objconexion);
                    comm.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                    comm.Parameters.AddWithValue("NumeroIdentidad", obj.NumeroIdentidad);
                    comm.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    comm.Parameters.AddWithValue("Correo", obj.Correo);
                    comm.Parameters.AddWithValue("Telefono", obj.Telefono);
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
        }*/
    }
}
