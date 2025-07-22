using CapaDatos;
using CapaEntidad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CapaDatos_Compras
    {
        public int ObtenerConsecutivo()
        {
            int IdConsecutivo = 0;

            using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) + 1 FROM COMPRA");
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

        public bool Registrar(Compra obj,DataTable DetalleCompra, out string Mensaje) 
        {
            bool Respuesta = false;
            Mensaje = String.Empty;

            using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand comm = new SqlCommand("SP_RegistrarCompra", objconexion);
                    comm.Parameters.AddWithValue("IdUsuario",obj.oUsuario.IdUsuario);
                    comm.Parameters.AddWithValue("IdProveedor",obj.oProveedor.IdProveedor);
                    comm.Parameters.AddWithValue("TipoCompra",obj.TipoCompra);
                    comm.Parameters.AddWithValue("NumeroCompra", obj.NumeroCompra);
                    comm.Parameters.AddWithValue("MontoNeto", obj.MontoNeto);
                    comm.Parameters.AddWithValue("Descuento", obj.Descuento);
                    comm.Parameters.AddWithValue("Subtotal", obj.Subtotal);
                    comm.Parameters.AddWithValue("IVA", obj.IVA);
                    comm.Parameters.AddWithValue("Total", obj.Total);
                    comm.Parameters.AddWithValue("DetalleCompra", DetalleCompra);
                    comm.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    comm.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    comm.CommandType = CommandType.StoredProcedure;

                    objconexion.Open();

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

    }
}
