using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace SalesLibrary
{
   public class Connection
    {
        internal SqlConnection Sqlconn;

        public SqlConnection SqlConn { get; set; }


        public Connection (string server, string database)
        {
            var connStr = $"server={server};database={database};trusted_connection=true";
            SqlConn = new SqlConnection(connStr);
            SqlConn.Open();
            if(SqlConn.State != System.Data.ConnectionState.Open)
            {
                SqlConn = null;
                throw new Exception("Connection did not open");
            }








        }











































    }
}
