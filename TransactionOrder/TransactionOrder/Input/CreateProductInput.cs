namespace TransactionOrder.TransactionOrder.Input
{
    public class CreateProductInput
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
        public string UploadImage { get; set; } = string.Empty;
    }
}
