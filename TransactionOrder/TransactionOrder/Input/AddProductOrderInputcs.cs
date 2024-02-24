namespace TransactionOrder.TransactionOrder.Input
{
    public class AddProductOrderInput
    {
        public string TransactionId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public int qty { get; set; }
        public double Price { get; set; }
        public string ProductImage { get; set; }
        public double Total { get; set; }
    }
}
