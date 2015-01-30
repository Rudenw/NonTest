using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonTestRepository.Entities
{
    public class Order
    {
        public List<OrderLine> OrderLines { get; set; }

        public double OrderValue { get; set; }

        public Address ShipToAddress { get; set; }
        public Address BillingAddress { get; set; }

        //Jag vet att detta inte är korrekt och det bör vara av objektet PaymentMethod men jag orkade inte fixa till just den biten
        public string PaymentMethod { get; set; }
    }
}
