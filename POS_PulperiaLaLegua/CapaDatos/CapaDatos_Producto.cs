using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CapaDatos_Producto
    {
        //Método para mostrar la lista de Productos
        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select p.IdProducto,p.Codigo,p.Nombre,p.Descripcion,c.IdProducto," +
                        "c.Descripcion[DescripcionProducto],p.Stock,p.PrecioCompra,p.PrecioVenta,p.Estado from Producto p");
                    query.AppendLine("INNER JOIN Producto c on c.IdProducto = p.IdProducto");
                    SqlCommand comm = new SqlCommand(query.ToString(), objconexion);
                    comm.CommandType = CommandType.Text;

                    objconexion.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Producto()
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                Codigo = dr["Codigo"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(dr["IdCategoria"]), Descripcion = dr["DescripcionCategoria"].ToString()},
                                Stock = Convert.ToInt32(dr["Stock"]),
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"].ToString()),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"].ToString()),
                                Estado = Convert.ToBoolean(dr["Estado"]),  
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Producto>();
                }
            }

            return lista;
        }


        //Método para crear nuevos Productos
        public int Registrar(Producto obj, out string Mensaje)
        {
            int IdProducto_Generado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand comm = new SqlCommand("SP_RegistrarProducto", objconexion);
                    comm.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    comm.Parameters.AddWithValue("Estado", obj.Estado);
                    comm.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    comm.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    comm.CommandType = CommandType.StoredProcedure;

                    objconexion.Open();

                    comm.ExecuteNonQuery();

                    IdProducto_Generado = Convert.ToInt32(comm.Parameters["Resultado"].Value);
                    Mensaje = comm.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                IdProducto_Generado = 0;
                Mensaje = ex.Message;
            }
            return IdProducto_Generado;
        }

        //Método para crear editar Productos
        public bool Editar(Producto obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand comm = new SqlCommand("SP_EditarProducto", objconexion);
                    comm.Parameters.AddWithValue("IdProducto", obj.IdProducto);
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

