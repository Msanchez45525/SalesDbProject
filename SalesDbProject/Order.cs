using System;
using System.Collections.Generic;
using System.Text;

namespace SalesDbProject
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
