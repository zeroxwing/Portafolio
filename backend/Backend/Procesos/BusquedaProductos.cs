using Backend.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Procesos
{
    public class BusquedaProductos : ConexionDB
    {
        private static SqlException _e = null;
        private static List<Productos> _p = null;

        private static bool Consultar(string p)
        {
            bool resultado = false;
            SqlConnection c = new SqlConnection();
            try
            {
                c = ConexionDB.Connection("DB_Productos");
                c.Open();
                StringBuilder st = new StringBuilder();
                st.Append("SELECT A.NOMBRE, A.MARCA, A.MODELO, A.COLOR, B.NOMBRE FROM ");
                st.Append("PRODUCTOS A INNER JOIN CLASIFICACIONES B ON A.CODCLASIFICACION = B.CODCLASIFICACION ");
                st.Append("WHERE A.NOMBRE LIKE '%" + p + "%'");
                string sql = st.ToString();
                SqlCommand command = new SqlCommand(sql, c);
                SqlDataReader r = command.ExecuteReader();
                if ( !string.IsNullOrEmpty(p) && r.HasRows)
                {
                    _p = new List<Productos>();
                    resultado = true;
                    while (r.Read())
                    {
                        Productos p2 = new Productos();
                        p2.Nombre = r.GetString(0);
                        p2.Marca = r.GetString(1);
                        p2.Modelo = r.GetString(2);
                        p2.Color = r.GetString(3);
                        p2.Clasificaciones.Nombre = r.GetString(4);
                        _p.Add(p2);
                    }
                }
            }
            catch (SqlException e)
            {
                _e = e;
            }
            finally
            {
                c.Close();
            }
            return resultado;
        }

        public static List<Productos> Busqueda(string p)
        {
            Consultar(p);
            return _p;
        }
    }
}
