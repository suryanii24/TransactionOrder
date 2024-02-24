using System.Threading.Tasks;
using System;
using TransactionOrder.Entities;
using TransactionOrder.TransactionOrder.Input;
using System.Linq;

namespace TransactionOrder.TransactionOrder
{
    public class TransactionOrderService : ITransactionOrderService
    {
        private readonly ApplicationDbContext _dbContext;

        public TransactionOrderService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<Product> CreateProduct(CreateProductInput input)
        {
            var data = _dbContext.Product.FirstOrDefault(x => x.ProductName == input.ProductName);
            if (data == null)
            {
                var Product = new Product
                {
                    ProductName = input.ProductName,
                    Price = input.Price,
                    CategoryId = Int32.Parse(input.Category),
                    Stock = input.Stock,
                    ProductImage = input.UploadImage,
                };

                await _dbContext.Product.AddAsync(Product);
                await _dbContext.SaveChangesAsync();

                Console.WriteLine("Product saved to the database.");
            }

            else
            {
                Console.WriteLine("Product already exists in the database.");
            }
            return data;
        }

    }
}
