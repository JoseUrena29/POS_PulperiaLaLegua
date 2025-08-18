using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Reflection;

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


        public Venta ObtenerVenta(string numero)
        {
            Venta obj = new Venta();
            using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select v.IdVenta,u.NombreCompleto,");
                    query.AppendLine("c.NumeroIdentidad,c.NombreCompleto,");
                    query.AppendLine("v.TipoPago,v.NumeroVenta,");
                    query.AppendLine("v.MontoNeto,v.Descuento,v.IVA,v.Subtotal,v.Total,v.MontoPago,v.MontoCambio,");
                    query.AppendLine("convert(char(10), v.FechaRegistro, 103)[FechaRegistro]");
                    query.AppendLine("from VENTA v");
                    query.AppendLine("inner join USUARIO u on u.IdUsuario = v.IdUsuario");
                    query.AppendLine("inner join CLIENTE c on c.IdCliente = v.IdCliente");
                    query.AppendLine("where v.NumeroVenta = @numero");

                    SqlCommand comm = new SqlCommand(query.ToString(), objconexion);
                    comm.Parameters.AddWithValue("@numero", numero);
                    comm.CommandType = CommandType.Text;

                    objconexion.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Venta()
                            {
                                IdVenta = Convert.ToInt32(dr["IdVenta"]),
                                oUsuario = new Usuario() { NombreCompleto = dr["NombreCompleto"].ToString() },
                                oCliente = new Cliente() { NumeroIdentidad = dr["NumeroIdentidad"].ToString(), NombreCompleto = dr["NombreCompleto"].ToString() },
                                TipoPago = dr["TipoPago"].ToString(),
                                NumeroVenta = dr["NumeroVenta"].ToString(),
                                MontoNeto = Convert.ToDecimal(dr["MontoNeto"].ToString()),
                                Descuento = Convert.ToDecimal(dr["Descuento"].ToString()),
                                Subtotal = Convert.ToDecimal(dr["Subtotal"].ToString()),
                                IVA = Convert.ToDecimal(dr["IVA"].ToString()),
                                Total = Convert.ToDecimal(dr["Total"].ToString()),
                                MontoPago = Convert.ToDecimal(dr["MontoPago"].ToString()),
                                MontoCambio = Convert.ToDecimal(dr["MontoCambio"].ToString()),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    obj = new Venta();
                }
            }
            return obj;
        }

        public List<DetalleVenta> ObtenerDetalleVenta(int IdVenta)
        {
            List<DetalleVenta> oLista = new List<DetalleVenta>();
            try
            {
                using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
                {
                    objconexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select p.Nombre,dv.PrecioVenta,dv.Cantidad,dv.SubTotal");
                    query.AppendLine("from DETALLE_VENTA dv");
                    query.AppendLine("inner join PRODUCTO p on p.IdProducto = dv.IdProducto");
                    query.AppendLine("where dv.IdVenta = @IdVenta");

                    SqlCommand comm = new SqlCommand(query.ToString(), objconexion);
                    comm.Parameters.AddWithValue("@IdVenta", IdVenta);
                    comm.CommandType = CommandType.Text;

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new DetalleVenta()
                            {
                                oProducto = new Producto() { Nombre = dr["Nombre"].ToString() },
                                PrecioVenta = Convert.ToDecimal(dr["Precio"].ToString()),
                                Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                SubTotal = Convert.ToDecimal(dr["SubTotal"].ToString()),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oLista = new List<DetalleVenta>();
            }
            return oLista;
        }
    }
}
