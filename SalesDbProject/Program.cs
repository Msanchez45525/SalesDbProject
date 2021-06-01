using System;
using SalesLibrary;

namespace SalesDbProject
{
   public class Program
    {
        static void Main(string[] args)
        {

            
                var connection = new Connection("localhost\\sqlexpress01", "SalesDb");
            var customerctrl = new CustomerController(connection);
            var newcusty = new Customer()
            {
                Id = 0,
                Name = "Fred",
                City = "Tampa",
                State = "FL",
                Sales = 1000,
                Active = true
            };
            var newcustomerworked = customerctrl.Create(newcusty);
            connection.Disconnect();


           

        }
    }
}
