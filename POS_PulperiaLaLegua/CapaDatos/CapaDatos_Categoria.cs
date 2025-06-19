using CapaEntidad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CapaDatos_Categoria
    {
        
        //Método para mostrar la lista de categorías
        public List<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();

            using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select IdCategoria,Descripcion,Estado from CATEGORIA");

                    SqlCommand comm = new SqlCommand(query.ToString(), objconexion);
                    comm.CommandType = CommandType.Text;

                    objconexion.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Categoria()
                            {
                                IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Categoria>();
                }
            }

            return lista;
        }


        //Método para crear nuevas categorías
        public int Registrar(Categoria obj, out string Mensaje)
        {
            int IdCategoria_Generado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand comm = new SqlCommand("SP_RegistrarCategoria", objconexion);
                    comm.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    comm.Parameters.AddWithValue("Estado", obj.Estado);
                    comm.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    comm.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    comm.CommandType = CommandType.StoredProcedure;

                    objconexion.Open();

                    comm.ExecuteNonQuery();

                    IdCategoria_Generado = Convert.ToInt32(comm.Parameters["Resultado"].Value);
                    Mensaje = comm.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                IdCategoria_Generado = 0;
                Mensaje = ex.Message;
            }
            return IdCategoria_Generado;
        }

        //Método para crear editar categorías
        public bool Editar(Categoria obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand comm = new SqlCommand("SP_EditarCategoria", objconexion);
                    comm.Parameters.AddWithValue("IdCategoria", obj.IdCategoria);
                    comm.Parameters.AddWithValue("Descripcion", obj.Descripcion);
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
