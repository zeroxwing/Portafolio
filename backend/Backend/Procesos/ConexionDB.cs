using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Backend.Procesos
{
    public class ConexionDB
    {
        private static string server = "dbtesis.database.windows.net";
        private static string user = "tesis";
        private static string passwd = "@UDP123456";
            
        public static SqlConnection Connection(string catalogo)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = server;
            builder.UserID = user;
            builder.Password = passwd;
            builder.InitialCatalog = catalogo;
            SqlConnection con = new SqlConnection(builder.ConnectionString);
            return con;
        }

    }
}
