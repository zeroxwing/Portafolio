using Backend.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Procesos
{
    public class Ingreso : ConexionDB
    {
        private static SqlException _e = null;

        public static Usuarios ValidarAcceso(string u, string p)
        {
            Usuarios user = new Usuarios();
            SqlConnection c = new SqlConnection();
            try
            {
                c = ConexionDB.Connection("DB_Usuarios");
                c.Open();
                StringBuilder st = new StringBuilder();
                st.Append("Select a.idusuario, a.rut, a.nombre, a.apellido, a.email, a.direccion, b.nombre, c.nombre, a.contrasena ");
                st.Append(" from dbo.usuarios a inner join dbo.comunas b on a.codcomuna = b.codcomuna inner join dbo.Regiones c on a.codregion = c.codregion ");
                st.Append("where Email='" + u + "' And contrasena='" + p + "'");
                string sql = st.ToString();
                SqlCommand command = new SqlCommand(sql, c);
                SqlDataReader r = command.ExecuteReader();
                if (!string.IsNullOrEmpty(u) && !string.IsNullOrEmpty(p) && r.HasRows)
                {
                    while (r.Read())
                    {
                        user.IdUsuario = r.GetInt32(0);
                        user.rut = r.GetString(1);
                        user.Nombre = r.GetString(2);
                        user.Apellido = r.GetString(3);
                        user.Email = r.GetString(4);
                        user.Direccion = r.GetString(5);
                        user.Comuna.Nombre = r.GetString(6);
                        user.Region.Nombre = r.GetString(7);
                     }

                }

            }catch(SqlException e)
            {
                _e = e;
            }
            finally
            {
                c.Close();
            }

            return user;
        }

        public static Usuarios Login(string u, string p)
        {
            return ValidarAcceso(u, p);
        }
    }
}
