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
using System.Reflection;

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


        public Compra ObtenerCompra(string numero)
        {
            Compra obj = new Compra();
            using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select c.IdCompra,");
                    query.AppendLine("u.NombreCompleto,");
                    query.AppendLine("pr.NumeroIdentidad,pr.NombreComercial,");
                    query.AppendLine("c.TipoCompra,c.NumeroCompra,c.MontoNeto,c.Descuento,c.Subtotal,c.IVA,c.Total,convert(char(10), c.FechaRegistro, 103)[FechaRegistro],convert(char(8),c.FechaRegistro, 108)[HoraRegistro]");
                    query.AppendLine("from COMPRA c");
                    query.AppendLine("inner join USUARIO u on u.IdUsuario = c.IdUsuario");
                    query.AppendLine("inner join PROVEEDOR pr on pr.IdProveedor = c.IdProveedor");
                    query.AppendLine("where c.NumeroCompra = @numero");

                    SqlCommand comm = new SqlCommand(query.ToString(), objconexion);
                    comm.Parameters.AddWithValue("@numero", numero);
                    comm.CommandType = CommandType.Text;

                    objconexion.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Compra()
                            {
                                IdCompra = Convert.ToInt32(dr["IdCompra"]),
                                oUsuario = new Usuario() { NombreCompleto = dr["NombreCompleto"].ToString()},
                                oProveedor = new Proveedor() { NumeroIdentidad = dr["NumeroIdentidad"].ToString(), NombreComercial = dr["NombreComercial"].ToString()},
                                TipoCompra = dr["TipoCompra"].ToString(),
                                NumeroCompra = dr["NumeroCompra"].ToString(),
                                MontoNeto = Convert.ToDecimal(dr["MontoNeto"].ToString()),
                                Descuento = Convert.ToDecimal(dr["Descuento"].ToString()),
                                Subtotal = Convert.ToDecimal(dr["Subtotal"].ToString()),
                                IVA = Convert.ToDecimal(dr["IVA"].ToString()),
                                Total = Convert.ToDecimal(dr["Total"].ToString()),
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                HoraRegistro = dr["HoraRegistro"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    obj = new Compra();
                }
            }
            return obj;
        }


        public List<DetalleCompra> ObtenerDetalleCompra(int IdCompra)
        {
            List<DetalleCompra> oLista = new List<DetalleCompra>();
            try
            {
                using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
                {
                    objconexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select p.Nombre,dc.PrecioCompra,dc.Cantidad,dc.MontoTotal");
                    query.AppendLine("from DETALLE_COMPRA dc");
                    query.AppendLine("inner join PRODUCTO p on p.IdProducto = dc.IdProducto");
                    query.AppendLine("where dc.IdCompra = @IdCompra");

                    SqlCommand comm = new SqlCommand(query.ToString(), objconexion);
                    comm.Parameters.AddWithValue("@IdCompra", IdCompra);
                    comm.CommandType = CommandType.Text;

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new DetalleCompra()
                            {
                                oProducto = new Producto() { Nombre = dr["Nombre"].ToString() },
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"].ToString()),
                                Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString()),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oLista = new List<DetalleCompra>();
            }
            return oLista;
        }
    }
}
