using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonTestRepository.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }

        public string Model { get; set; }

        private double _price;
        public double Price {
            get 
            { 
                if (BundleItem)
                {
                    return Products.Sum(p => p.Price);
                }
                else
                {
                    return _price;
                }
            }
            set { _price = value; }
        }

        public List<Product> Products = new List<Product>();
        public bool BundleItem
        {
            get
            {
                return Products != null && Products.Any();
            }
        }
    }
}
