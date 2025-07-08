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
    public class CapaDatos_Cliente
    {
        //Método para mostrar la lista de Clientes
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdCliente,NumeroIdentidad,NombreCompleto,Correo,Telefono,Estado from CLIENTE");
                    SqlCommand comm = new SqlCommand(query.ToString(), objconexion);
                    comm.CommandType = CommandType.Text;

                    objconexion.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente()
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                NumeroIdentidad = dr["NumeroIdentidad"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Cliente>();
                }
            }
            return lista;
        }


        //Método para crear nuevos Clientes
        public int Registrar(Cliente obj, out string Mensaje)
        {
            int IdCliente_Generado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand comm = new SqlCommand("SP_RegistrarCliente", objconexion);
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

                    IdCliente_Generado = Convert.ToInt32(comm.Parameters["Resultado"].Value);
                    Mensaje = comm.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                IdCliente_Generado = 0;
                Mensaje = ex.Message;
            }
            return IdCliente_Generado;
        }

        //Método para crear editar Clientes
        public bool Editar(Cliente obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand comm = new SqlCommand("SP_EditarCliente", objconexion);
                    comm.Parameters.AddWithValue("IdCliente", obj.IdCliente);
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
        }
    }
}
