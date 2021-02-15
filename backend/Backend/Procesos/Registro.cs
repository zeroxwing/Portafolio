using Backend.Models;
using Backend.Servicios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Procesos
{
    public class Registro : Ingreso
    {
        private static SqlException _e = null;

        private static bool GrabarUsuario(Usuarios u)
        {
            bool resultado = false;
            SqlConnection c = new SqlConnection();
            try
            {
                c = ConexionDB.Connection("DB_Usuarios");
                c.Open();
                StringBuilder st = new StringBuilder();
                    st.Append("Insert into dbo.usuarios ");
                st.Append("(RUT,NOMBRE,APELLIDO,EMAIL,CODREGION,CODCOMUNA,DIRECCION,CONTRASENA) ");
                st.Append("VALUES('" + u.rut + "','" + u.Nombre + "','" + u.Apellido + "','" + u.Email + "'," + u.Region.CodRegion + "," + u.Comuna.CodComuna + ",'" + u.Direccion + "','" + u.Password + "')");
                string sql = st.ToString();
                SqlCommand command = new SqlCommand(sql, c);
                if (command.ExecuteNonQuery() > 0)
                {
                    resultado = true;
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

        public static bool Register(Usuarios u)
        {
            bool r = false;
            if (string.IsNullOrEmpty(ValidarAcceso(u.Email, u.Password).Nombre)){
                if (GrabarUsuario(u))
                {
                    r = true;
                }
            }
            return r;
        }

    }
}
