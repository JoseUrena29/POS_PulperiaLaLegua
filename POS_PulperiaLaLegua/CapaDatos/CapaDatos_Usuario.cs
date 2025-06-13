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
        public List<Usuarios> Listar()
        {
            List<Usuarios> lista = new List<Usuarios>();

            using (SqlConnection objconexion = new SqlConnection(Conexion.cadena)) 
            {

                try
                {
                    string query = "select IdUsuario,NumeroIdentidad,NombreCompleto,Correo,Telefono,Usuario,Contraseña,Estado from USUARIO";

                    SqlCommand comm = new SqlCommand(query, objconexion);
                    comm.CommandType = CommandType.Text;

                    objconexion.Open();

                    using (SqlDataReader dr = comm.ExecuteReader()) 
                    {
                        while (dr.Read()) 
                        {
                            lista.Add(new Usuarios()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                NumeroIdentidad = dr["NumeroIdentidad"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Usuario = dr["Usuario"].ToString(),
                                Contraseña = dr["Contraseña"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            }); 
                        }
                    }  
                }
                catch (Exception ex) 
                { 
                    lista = new List<Usuarios>();
                }
            }

            return lista;
       }
    }
}
