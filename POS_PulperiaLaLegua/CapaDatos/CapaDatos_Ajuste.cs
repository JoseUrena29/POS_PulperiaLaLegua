using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Runtime.Remoting;

namespace CapaDatos
{
    public class CapaDatos_Ajuste
    {
        //Método para la creación de consecutivo para el número de los ajustes
        public int ObtenerConsecutivo()
        {
            int IdConsecutivo = 0;

            using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) + 1 FROM AJUSTE");
                    SqlCommand comm = new SqlCommand(query.ToString(), objconexion);
                    comm.CommandType = CommandType.Text;

                    objconexion.Open();

                    IdConsecutivo = Convert.ToInt32(comm.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    IdConsecutivo = 0;
                }
            }
            return IdConsecutivo;
        }

        public bool Registrar(Ajuste obj, DataTable DetalleAjuste, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = String.Empty;

            using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand comm = new SqlCommand("SP_RegistrarAjuste", objconexion);
                    comm.Parameters.AddWithValue("IdUsuario", obj.oUsuario.IdUsuario);
                    comm.Parameters.AddWithValue("TipoAjuste", obj.TipoAjuste);
                    comm.Parameters.AddWithValue("NumeroAjuste", obj.NumeroAjuste);
                    comm.Parameters.AddWithValue("MotivoGeneral", obj.MotivoGeneral);
                    comm.Parameters.AddWithValue("Observaciones", obj.Observaciones);
                    comm.Parameters.AddWithValue("DetalleAjuste", DetalleAjuste);
                    comm.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    comm.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    comm.CommandType = CommandType.StoredProcedure;

                    objconexion.Open();

                    comm.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(comm.Parameters["Resultado"].Value);
                    Mensaje = comm.Parameters["Mensaje"].Value.ToString();
                }
                catch (Exception ex)
                {
                    Respuesta = false;
                    Mensaje = ex.Message;
                }
            }
            return Respuesta;
        }


        public Ajuste ObtenerAjuste(string numero)
        {
            Ajuste obj = new Ajuste();
            using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT");
                    query.AppendLine("a.IdAjuste,u.NombreCompleto,a.TipoAjuste,a.NumeroAjuste,a.MotivoGeneral,a.Observaciones,");
                    query.AppendLine("CONVERT(CHAR(10), a.FechaRegistro, 103) AS FechaRegistro,");
                    query.AppendLine("CONVERT(CHAR(8), a.FechaRegistro, 108) AS HoraRegistro");
                    query.AppendLine("FROM AJUSTE a");
                    query.AppendLine("INNER JOIN USUARIO u ON u.IdUsuario = a.IdUsuario");
                    query.AppendLine("WHERE a.NumeroAjuste = @numero");

                    SqlCommand comm = new SqlCommand(query.ToString(), objconexion);
                    comm.Parameters.AddWithValue("@numero", numero);
                    comm.CommandType = CommandType.Text;

                    objconexion.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Ajuste()
                            {
                                IdAjuste = Convert.ToInt32(dr["IdAjuste"]),
                                oUsuario = new Usuario() { NombreCompleto = dr["NombreCompleto"].ToString() },
                                TipoAjuste = dr["TipoAjuste"].ToString(),
                                NumeroAjuste = dr["NumeroAjuste"].ToString(),
                                MotivoGeneral = dr["MotivoGeneral"].ToString(),
                                Observaciones = dr["Observaciones"].ToString(),
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                HoraRegistro = dr["HoraRegistro"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    obj = new Ajuste();
                }
            }
            return obj;
        }

        public List<DetalleAjuste> ObtenerDetalleAjuste(int IdAjuste)
        {
            List<DetalleAjuste> oLista = new List<DetalleAjuste>();
            try
            {
                using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
                {
                    objconexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT");
                    query.AppendLine("p.Codigo AS Codigo,p.Nombre AS Producto,da.StockAnterior,da.Cantidad,da.StockNuevo");
                    query.AppendLine("FROM DETALLE_AJUSTE da");
                    query.AppendLine("INNER JOIN PRODUCTO p ON p.IdProducto = da.IdProducto");
                    query.AppendLine("WHERE da.IdAjuste = @IdAjuste");

                    SqlCommand comm = new SqlCommand(query.ToString(), objconexion);
                    comm.Parameters.AddWithValue("@IdAjuste", IdAjuste);
                    comm.CommandType = CommandType.Text;

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new DetalleAjuste()
                            {
                                oProducto = new Producto()
                                {
                                    Codigo = dr["Codigo"].ToString(),
                                    Nombre = dr["Producto"].ToString()
                                },
                                StockAnterior = Convert.ToInt32(dr["StockAnterior"].ToString()),
                                StockNuevo = Convert.ToInt32(dr["StockNuevo"].ToString()),
                                Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oLista = new List<DetalleAjuste>();
            }
            return oLista;
        }
    }
}
