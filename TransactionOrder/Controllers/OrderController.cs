using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using System;
using TransactionOrder.Entities;
using TransactionOrder.TransactionOrder.Input;
using TransactionOrder.TransactionOrder.Models;
using System.Collections.Generic;

namespace TransactionOrder.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpPost("order")]
        public async Task<Order> AddOrderTransaction(OrderInput input)
        {
            var data = _dbContext.Order.FirstOrDefault(x => x.TransactionNumber == input.TransactionNumber);
            if (data == null)
            {
                var order = new Order
                {
                    TransactionNumber = input.TransactionNumber,
                    TransactionDate = DateTime.UtcNow,
                    CashierName = input.CashierName,
                };

                await _dbContext.Order.AddAsync(order);
                await _dbContext.SaveChangesAsync();

                Console.WriteLine("Order saved to the database.");
            }

            else
            {
                Console.WriteLine("Order already exists in the database.");
            }
            return data;
        }

        [HttpPost("Transaction")]
        public List<TransactionCustomModel> AddProductOrder(AddProductOrderInput input)
        {
            var data = _dbContext.Order.FirstOrDefault(x => x.TransactionId == input.TransactionId);
            var customModelList = new List<TransactionCustomModel>();

            if (data != null)
            {
                var Productorder = new TransactionCustomModel()
                {
                    ProductName = input.ProductName,
                    Category = input.Category,
                    qty = input.qty,
                    Price = input.Price,
                    Total = input.Total,
                    ProductImage = input.ProductImage
                };

                customModelList.Add(Productorder);
            }
            return customModelList;
        }

        [HttpGet("Transaction")]
        public IEnumerable<TransactionCustomModel> GetProducts()
        {
            var query = new List<TransactionCustomModel>();
            return query.Select( x => new TransactionCustomModel() 
            {
                ProductName = x.ProductName,
                Category = x.Category,
                qty=x.qty,
                Price = x.Price,
                Total = x.Price * 2,
                ProductImage = x.ProductImage
            }).ToList();                                  
        }

        [HttpDelete("Transaction")]
        public IActionResult DeleteProduct(string id)
        {
            var transactionRemove = _dbContext.OrderDetail.FirstOrDefault(p => p.TransactionId == id);
            if (transactionRemove == null)
            {
                return NotFound();
            }

            _dbContext.OrderDetail.Remove(transactionRemove);
            return Ok(transactionRemove);
        }

        [HttpGet("Order")]
        public IQueryable<Order>GetOrders(TransactionInput input)
        {
            var query = (from o in _dbContext.Order
                         where o.TransactionDate>= input.StartDate && o.TransactionDate<=input.EndDate
                         select o).ToList();
            return query.AsQueryable();
        }
    }
}
