using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CapaDatos_Ventas
    {
        //Método para la creación de consecutivo para el número de las ventas
        public int ObtenerConsecutivo()
        {
            int IdConsecutivo = 0;

            using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) + 1 FROM VENTA");
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

        //Método para restar la cantidad del Stock de los productos en las ventas
        public bool RestarStock(int IdProducto, int cantidad)
        {
            bool respuesta = true;

            using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE PRODUCTO SET stock = stock - @cantidad where IdProducto = @IdProducto");

                    SqlCommand comm = new SqlCommand(query.ToString(), objconexion);
                    comm.Parameters.AddWithValue("@cantidad", cantidad);
                    comm.Parameters.AddWithValue("@IdProducto", IdProducto);
                    comm.CommandType = CommandType.Text;

                    objconexion.Open();

                    respuesta = comm.ExecuteNonQuery() > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        //Método para sumnar la cantidad del Stock de los productos en las ventas
        public bool SumarStock(int IdProducto, int cantidad)
        {
            bool respuesta = true;

            using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE PRODUCTO SET stock = stock + @cantidad where IdProducto = @IdProducto");

                    SqlCommand comm = new SqlCommand(query.ToString(), objconexion);
                    comm.Parameters.AddWithValue("@cantidad", cantidad);
                    comm.Parameters.AddWithValue("@IdProducto", IdProducto);
                    comm.CommandType = CommandType.Text;

                    objconexion.Open();

                    respuesta = comm.ExecuteNonQuery() > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        //Método para registrar las ventas en la Base de Datos SQL
        public bool Registrar(Venta obj, DataTable DetalleVenta, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = String.Empty;

            using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand comm = new SqlCommand("SP_RegistrarVenta", objconexion);
                    comm.Parameters.AddWithValue("IdUsuario", obj.oUsuario.IdUsuario);
                    comm.Parameters.AddWithValue("IdCliente", obj.oCliente.IdCliente);
                    comm.Parameters.AddWithValue("TipoPago", obj.TipoPago);
                    comm.Parameters.AddWithValue("NumeroVenta", obj.NumeroVenta);
                    comm.Parameters.AddWithValue("MontoNeto", obj.MontoNeto);
                    comm.Parameters.AddWithValue("Descuento", obj.Descuento);
                    comm.Parameters.AddWithValue("Subtotal", obj.Subtotal);
                    comm.Parameters.AddWithValue("IVA", obj.IVA);
                    comm.Parameters.AddWithValue("Total", obj.Total);
                    comm.Parameters.AddWithValue("MontoPago", obj.MontoPago);
                    comm.Parameters.AddWithValue("MontoCambio", obj.MontoCambio);
                    comm.Parameters.AddWithValue("DetalleVenta", DetalleVenta);
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







    }
}
