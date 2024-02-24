using System;

namespace TransactionOrder.TransactionOrder.Input
{
    public class OrderInput
    {
        public string TransactionNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CashierName { get; set; }
    }
}
