using System;
using System.Collections.Generic;

namespace TransactionOrder.Entities
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public int Stock { get; set; }
        public string ProductImage { get; set; }
    }
}
