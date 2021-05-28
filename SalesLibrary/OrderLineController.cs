using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using SalesDbProject;

namespace SalesLibrary
{
    public class OrderLineController
    {

        private static Connection connection { get; set; }


        public OrderLineController(Connection connection)
        {
            OrderLineController.connection = connection;
        }



        public bool Create(Orderline orderline)
        {
            var sql = $"INSERT into Orderlines " +
                " (OrdersId, Product, Description, Quantity, Price) " +
                " VALUES " + $" (@orderid, @product, @description, @quantity, " +
                $" @price); ";
            var sqlcmd = new SqlCommand(sql, connection.SqlConn);
            sqlcmd.Parameters.AddWithValue("@ordersid", orderline.OrdersId);
            sqlcmd.Parameters.AddWithValue("@product", orderline.Product);
            sqlcmd.Parameters.AddWithValue("@description", orderline.Description);
            sqlcmd.Parameters.AddWithValue("@quantity", orderline.Quantity);
            sqlcmd.Parameters.AddWithValue("@price", orderline.Price);
            var rowsAffected = sqlcmd.ExecuteNonQuery();

            return (rowsAffected == 1);

        }



        public Orderline GetByPk(int id)
        {

            var sql = $"SELECT * From OrderLines where id = {id}";
            var sqlcmd = new SqlCommand(sql, connection.SqlConn);
            var sqldatareader = sqlcmd.ExecuteReader();
            if (!sqldatareader.HasRows)
            {
                return null;
            }
            sqldatareader.Read();
            var user = new Orderline()
            {
                Id = Convert.ToInt32(sqldatareader["Id"]),
                OrdersId = Convert.ToInt32(sqldatareader["OrdersId"]),
                Product = Convert.ToString(sqldatareader["Product"]),
                Description = Convert.ToString(sqldatareader["Description"]),
                Quantity = Convert.ToInt32(sqldatareader["Quantity"]),
                Price = Convert.ToDecimal(sqldatareader["Price"]),

            };
            sqldatareader.Close();
            return user;

        }



        public List<Orderline> GetAllOrderLine()
        {

            var sql = "SELECT * from Orderlines;";
            var sqlcmd = new SqlCommand(sql, connection.SqlConn);

            var sqldatareader = sqlcmd.ExecuteReader();
            var orderline = new List<Orderline>();
            while (sqldatareader.Read())
            {
                var id = Convert.ToInt32(sqldatareader["Id"]);
                var orderid = Convert.ToInt32(sqldatareader["OrderId"]);
                var product = Convert.ToString(sqldatareader["Product"]);
                var description = Convert.ToString(sqldatareader["DEscription"]);
                var quantity = Convert.ToInt32(sqldatareader["Quantity"]);
                var price = Convert.ToDecimal(sqldatareader["Price"]);
                var Orderline = new Orderline()
                {
                    Id = id,
                    OrdersId = orderid,
                    Product = product,
                    Description = description,
                    Quantity = quantity,
                    Price = price
                };
                orderline.Add(Orderline);

            }
            sqldatareader.Close();
            return orderline;

        }




        public bool Change(Orderline orderline)
        {
            var sql = $"Update Orderlines Set" +
                " OrderId = @orderid, " +
                "Product = @cityproduct, " +
                "Description = @description, " +
                "Quantity = @quantity, " +
                "Price = @[rice, " +
                "Where Id = @id;";
            var sqlcmd = new SqlCommand(sql, connection.SqlConn);
            sqlcmd.Parameters.AddWithValue("@ordersid", orderline.OrdersId);
            sqlcmd.Parameters.AddWithValue("@product", orderline.Product);
            sqlcmd.Parameters.AddWithValue("@description", orderline.Description);
            sqlcmd.Parameters.AddWithValue("@quantity", orderline.Quantity);
            sqlcmd.Parameters.AddWithValue("@price", orderline.Price);
            var rowsAffected = sqlcmd.ExecuteNonQuery();
            return (rowsAffected == 1);


        }



        public bool Delete(Orderline orderline)
        {
            var sql = $"Delete from Customers" +
                "Where Id = @id";
            var sqlcmd = new SqlCommand(sql, connection.SqlConn);
            sqlcmd.Parameters.AddWithValue("@id", orderline.Id);
            var rowsAffected = sqlcmd.ExecuteNonQuery();
            return (rowsAffected == 1);

        }










































    }
}
