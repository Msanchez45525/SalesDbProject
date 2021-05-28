using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using SalesLibrary;

namespace SalesDbProject
{
   public class CustomerController
    {

        private static Connection connection { get; set; }





        public bool Delete(Customer customer)
        {
            var sql = $"Delete from Customers " +
             "Where Id = @Id ";
            var sqlcmd = new SqlCommand(sql, connection.SqlConn);
            sqlcmd.Parameters.AddWithValue("@id", request.Id);
            var rowsAffected = sqlcmd.ExecuteNonQuery();
            return (rowsAffected == 1);


        }























  







    }
}
