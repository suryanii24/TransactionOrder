using System;
using System.Collections.Generic;

namespace TransactionOrder.Entities
{
    public partial class OrderDetail
    {
        public string TransactionDetailId { get; set; }
        public string TransactionId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public double TotalPrice { get; set; }
    }
}
