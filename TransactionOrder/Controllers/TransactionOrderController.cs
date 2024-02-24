using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionOrder.Entities;
using TransactionOrder.TransactionOrder.Input;
using TransactionOrder.TransactionOrder.Models;

namespace TransactionOrder.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionOrderController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ApplicationDbContext _dbContext;

        private readonly ILogger<TransactionOrderController> _logger;

        public TransactionOrderController(ILogger<TransactionOrderController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpPost("masterproduct")]
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

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
