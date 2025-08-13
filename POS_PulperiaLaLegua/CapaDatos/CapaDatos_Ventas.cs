using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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






    }
}
