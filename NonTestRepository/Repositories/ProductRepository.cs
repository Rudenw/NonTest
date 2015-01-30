using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NonTestRepository.Entities;

namespace NonTestRepository.Repositories
{
    public class ProductRepository
    {
        private List<Product> _products;

        public List<Product> GetAllProducts()
        {
            //For test purposes, we simply create a few dummyproducts and return them
            _products = new List<Product>();

            _products.Add(new Product() {Id = 1, Name = "SuperDator med Skärm", Brand = "RobinMärket", Products = new List<Product> { new Product { Id = 2, Name = "SuperDator", Brand = "RobinMärket", Model = "R2800", Price = 8444 }, new Product { Id = 3, Name = "En okej skärm", Brand = "RobinMärket", Model = "CRT15", Price = 1555 } } });
            _products.Add(new Product{ Id = 2, Name = "SuperDator", Brand = "RobinMärket", Model = "R2800", Price = 8990 });
            _products.Add(new Product {Id = 4, Name = "Bra TV", Brand = "AnnatMärke", Model = "L4201", Price = 4990 });
            _products.Add(new Product {Id = 5, Name = "Fin Lampa", Brand = "LF", Model = "B1234", Price = 90 });

            return _products;
        }

        public Product GetProductFromId(int productId)
        {
            return _products.FirstOrDefault(x => x.Id == productId) ?? new Product { Id = productId, Name = "Error, product not found"};
        }

        public Product GetFreightCost(double freightCost)
        {
            return new Product {Id = 99, Name = "Freight Cost", Price = freightCost};
        }
    }
}
