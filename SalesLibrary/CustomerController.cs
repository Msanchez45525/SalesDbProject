using System;
using System.Collections.Generic;

using System.Text;
using Microsoft.Data.SqlClient;
using SalesLibrary;

namespace SalesDbProject
{
   public class CustomerController
    {

        private static Connection connection { get; set; }

        public CustomerController(Connection connection)
        {
            CustomerController.connection = connection;
        }



        public bool Create(Customer customer)
        {
            var sql = $"INSERT into Customers"  +
                " (Name, City, State, Sales, Active) " + " VALUES ( @name, @city, @state, @sales,  @active); ";
            var sqlcmd = new SqlCommand(sql, connection.SqlConn);
            sqlcmd.Parameters.AddWithValue("@Id", customer.Id);
            sqlcmd.Parameters.AddWithValue("@name", customer.Name);
            sqlcmd.Parameters.AddWithValue("@city", customer.City);
            sqlcmd.Parameters.AddWithValue("@state", customer.State);
            sqlcmd.Parameters.AddWithValue("@sales", customer.Sales);
            sqlcmd.Parameters.AddWithValue("@active", customer.Active);
            var rowsAffected = sqlcmd.ExecuteNonQuery();

            return (rowsAffected == 1);

        }



        public Customer GetByPk(int id)
        {

            var sql = $"SELECT * From Customers where id = {id}";
            var sqlcmd = new SqlCommand(sql, connection.SqlConn);
            var sqldatareader = sqlcmd.ExecuteReader();
            if (!sqldatareader.HasRows)
            {
                return null;
            }
            sqldatareader.Read();
            var user = new Customer()
            {
                Id = Convert.ToInt32(sqldatareader["Id"]),
                Name = Convert.ToString(sqldatareader["Name"]),
                City = Convert.ToString(sqldatareader["City"]),
                State = Convert.ToString(sqldatareader["State"]),
                Sales = Convert.ToDecimal(sqldatareader["Sales"]),
                Active = Convert.ToBoolean(sqldatareader["Active"]),
          
            };
            sqldatareader.Close();
            return user;

        }



        public List<Customer> GetAllCustomers()
        {

            var sql = "SELECT * from Customers;";
            var sqlcmd = new SqlCommand(sql, connection.SqlConn);

            var sqldatareader = sqlcmd.ExecuteReader();
            var customer = new List<Customer>();
            while (sqldatareader.Read())
            {
                var id = Convert.ToInt32(sqldatareader["Id"]);
                var name = Convert.ToString(sqldatareader["Name"]);
                var city = Convert.ToString(sqldatareader["City"]);
                var state = Convert.ToString(sqldatareader["State"]);
                var sales = Convert.ToDecimal(sqldatareader["Sales"]);
                var active = Convert.ToBoolean(sqldatareader["Name"]);
                var Customer = new Customer()
                {
                    Id = id,
                    Name = name,
                    City = city,
                    State = state,
                    Sales = sales,
                    Active = active
                };
                customer.Add(Customer);

            }
            sqldatareader.Close();
            return customer;

        }




        public bool Change(Customer customer)
        {
            var sql = $"Update Customers Set" +
                " Name = @name, " +
                "City = @city, " +
                "State = @state, " +
                "Sales = @sales, " +
                "Active = @active, " +
                "Where Id = @id;";
            var sqlcmd = new SqlCommand(sql, connection.SqlConn);
            sqlcmd.Parameters.AddWithValue("@name", customer.Name);
            sqlcmd.Parameters.AddWithValue("@city", customer.City);
            sqlcmd.Parameters.AddWithValue("@state", customer.State);
            sqlcmd.Parameters.AddWithValue("@sales", customer.Sales);
            sqlcmd.Parameters.AddWithValue("@active", customer.Active);
            var rowsAffected = sqlcmd.ExecuteNonQuery();
            return (rowsAffected == 1);


        }



        public bool Delete(Customer customer)
        {
            var sql = $" Delete from Customers " +
                "Where Id = @id";
            var sqlcmd = new SqlCommand(sql, connection.SqlConn);
            sqlcmd.Parameters.AddWithValue("@id", customer.Id);
            var rowsAffected = sqlcmd.ExecuteNonQuery();
            return (rowsAffected == 1);
 
        }







    }
}
