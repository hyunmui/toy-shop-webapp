using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Practice.Models;
using Practice.Repositories;

namespace Practice.Services
{
    public class ProductService
    {
        private OrderingContext OrderingContext { get; }

        public ProductService(OrderingContext orderingContext)
        {
            this.OrderingContext = orderingContext;
        }

        public IList<Product> GetProducts()
        {
            return (from product in OrderingContext.Products
                    select product).ToList();
        }

        public bool AddProduct(Product product)
        {
            var result = OrderingContext.Products.Add(product).State == EntityState.Added;
            OrderingContext.SaveChanges();
            return result;
        }

        public Product GetProduct(int id)
        {
            return OrderingContext.Products.SingleOrDefault(product => product.Id == id);
        }

        public bool UpdateProduct(Product product)
        {
            var result = OrderingContext.Products.Update(product).State == EntityState.Modified;
            OrderingContext.SaveChanges();
            return result;
        }
    }
}