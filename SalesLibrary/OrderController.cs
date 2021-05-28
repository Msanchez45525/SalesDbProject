using Microsoft.Data.SqlClient;
using SalesDbProject;
using System;
using System.Collections.Generic;

namespace SalesLibrary
{
    public class OrderController
    {
        private static Connection connection { get; set; }

        public OrderController(Connection connection)
        {
            OrderController.connection = connection;
        }

        public bool Create(Order order)
        {
            var sql = $"INSERT into Orders " +
                " (CustomerId, Date, Description,)" +
                " VALUES " + $" (@customerid, @date, @description,); " ;
                var sqlcmd = new SqlCommand(sql, connection.SqlConn);
                  sqlcmd.Parameters.AddWithValue("@customerid", order.CustomerId);
                  sqlcmd.Parameters.AddWithValue("@date", order.Date);
                  sqlcmd.Parameters.AddWithValue("@description", order.Description);
            var rowsAffected = sqlcmd.ExecuteNonQuery();

            return (rowsAffected == 1);
        }

        public Order GetByPk(int id)
        {
            var sql = $"SELECT * From Order where id = {id}";
            var sqlcmd = new SqlCommand(sql, connection.SqlConn);
            var sqldatareader = sqlcmd.ExecuteReader();
            if (!sqldatareader.HasRows)
            {
                return null;
            }
            sqldatareader.Read();
            var order = new Order()
            {
                CustomerId = Convert.ToInt32(sqldatareader["CustomerId"]),
                Date = Convert.ToDateTime(sqldatareader["Date"]),
                Description = Convert.ToString(sqldatareader["Description"]),
            };
            sqldatareader.Close();
            return order;
        }

         public List<Order> GetAllOrders()
        {
            var sql = "SELECT * from Orders";
            var sqlcmd = new SqlCommand(sql, connection.SqlConn);
            var sqldatareader = sqlcmd.ExecuteReader();
            var orders = new List<Order>();
            while (sqldatareader.Read())
            {
                var customerid = Convert.ToInt32(sqldatareader["CustomerId"]);
                var date = Convert.ToDateTime(sqldatareader["Date"]);
                var description = Convert.ToString(sqldatareader["Description"]);
                var order = new Order()
                {
                    CustomerId = customerid,
                    Date = date,
                    Description = description,
                };
                orders.Add(order);
            }
            return orders;
        }

        public bool Change(Order order)
        {
            var sql = $" Update Orders Set " +
                "CustomerId = @customerid, " +
                "Date = @date, " +
                "Description = @description, " +
                "Where Id = @id";
            var sqlcmd = new SqlCommand(sql, connection.SqlConn);
            sqlcmd.Parameters.AddWithValue("@customerid", order.CustomerId);
            sqlcmd.Parameters.AddWithValue("@date", order.Date);
            sqlcmd.Parameters.AddWithValue("@description", order.Description);
            var rowsAffected = sqlcmd.ExecuteNonQuery();
            return (rowsAffected == 1);
        }

        public bool Delete(Order orders)
        {
            var sql = $"Delete from Orders" +
                "Where Id = @id;";
            var sqlcmd = new SqlCommand(sql, connection.SqlConn);
            sqlcmd.Parameters.AddWithValue("@id", orders.Id);
            var rowsAffected = sqlcmd.ExecuteNonQuery();
            return (rowsAffected ==1);
        }

    }
}
