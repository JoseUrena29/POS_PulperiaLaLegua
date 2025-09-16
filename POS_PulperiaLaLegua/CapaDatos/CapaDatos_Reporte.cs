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
    public class CapaDatos_Reporte
    {
        //Método para obtener el listado del reporte de compras
        public List<ReporteCompra> Compra(string fechainicio, string fechafin, int IdProveedor)
        {
            List<ReporteCompra> Lista = new List<ReporteCompra>();

            using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    SqlCommand comm = new SqlCommand("SP_ReporteCompras", objconexion);
                    comm.Parameters.AddWithValue("fechainicio", fechainicio);
                    comm.Parameters.AddWithValue("fechafin", fechafin);
                    comm.Parameters.AddWithValue("IdProveedor", IdProveedor);
                    comm.CommandType = CommandType.StoredProcedure;

                    objconexion.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(new ReporteCompra()
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                Hora = dr["Hora"].ToString(),
                                TipoCompra = dr["TipoCompra"].ToString(),
                                NumeroCompra = dr["NumeroCompra"].ToString(),
                                UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                                NumeroIdentidadProveedor = dr["NumeroIdentidadProveedor"].ToString(),
                                NombreProveedor = dr["NombreProveedor"].ToString(),
                                CodigoProducto = dr["CodigoProducto"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                DescripcionProducto = dr["DescripcionProducto"].ToString(),
                                Categoria = dr["Categoria"].ToString(),
                                PrecioCompra = dr["PrecioCompra"].ToString(),
                                PrecioVenta = dr["PrecioVenta"].ToString(),
                                Cantidad = dr["Cantidad"].ToString(),
                                SubTotalProductos = dr["SubTotalProductos"].ToString(),
                                MontoNeto = dr["MontoNeto"].ToString(),
                                Descuento = dr["Descuento"].ToString(),
                                SubTotal = dr["SubTotal"].ToString(),
                                IVA = dr["IVA"].ToString(),
                                Total = dr["Total"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Lista = new List<ReporteCompra>();
                }
                return Lista;
            }
        }


        //Método para obtener el listado del reporte de ventas
        public List<ReporteVenta> Venta(string fechainicio, string fechafin)
        {
            List<ReporteVenta> Lista = new List<ReporteVenta>();

            using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    SqlCommand comm = new SqlCommand("SP_ReporteVentas", objconexion);
                    comm.Parameters.AddWithValue("fechainicio", fechainicio);
                    comm.Parameters.AddWithValue("fechafin", fechafin);
                    comm.CommandType = CommandType.StoredProcedure;

                    objconexion.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(new ReporteVenta()
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                Hora = dr["Hora"].ToString(),
                                TipoPago = dr["TipoPago"].ToString(),
                                NumeroVenta = dr["NumeroVenta"].ToString(),
                                UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                                NumeroIdentidadCliente = dr["NumeroIdentidadCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                CodigoProducto = dr["CodigoProducto"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                DescripcionProducto = dr["DescripcionProducto"].ToString(),
                                Categoria = dr["Categoria"].ToString(),
                                PrecioVenta = dr["PrecioVenta"].ToString(),
                                Cantidad = dr["Cantidad"].ToString(),
                                SubTotalProductos = dr["SubTotalProductos"].ToString(),
                                MontoNeto = dr["MontoNeto"].ToString(),
                                Descuento = dr["Descuento"].ToString(),
                                SubTotal = dr["SubTotal"].ToString(),
                                IVA = dr["IVA"].ToString(),
                                Total = dr["Total"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Lista = new List<ReporteVenta>();
                }
                return Lista;
            }
        }

        //Método para obtener el listado del reporte de ajustes
        public List<ReporteAjuste> Ajuste(string fechainicio, string fechafin)
        {
            List<ReporteAjuste> Lista = new List<ReporteAjuste>();

            using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    SqlCommand comm = new SqlCommand("SP_ReporteAjustes", objconexion);
                    comm.Parameters.AddWithValue("fechainicio", fechainicio);
                    comm.Parameters.AddWithValue("fechafin", fechafin);
                    comm.CommandType = CommandType.StoredProcedure;

                    objconexion.Open();

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(new ReporteAjuste()
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                Hora = dr["Hora"].ToString(),
                                TipoAjuste = dr["TipoAjuste"].ToString(),
                                NumeroAjuste = dr["NumeroAjuste"].ToString(),
                                MotivoGeneral = dr["MotivoGeneral"].ToString(),
                                Observaciones = dr["Observaciones"].ToString(),
                                UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                                CodigoProducto = dr["CodigoProducto"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                DescripcionProducto = dr["DescripcionProducto"].ToString(),
                                Categoria = dr["Categoria"].ToString(),
                                StockAnterior = dr["StockAnterior"].ToString(),
                                CantidadAjuste = dr["CantidadAjuste"].ToString(),
                                StockNuevo = dr["StockNuevo"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Lista = new List<ReporteAjuste>();
                }
                return Lista;
            }
        }
    }
}
