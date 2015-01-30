using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NonTestRepository.Entities;

namespace NonTestRepository.Repositories
{
    public class PaymentMethodRepository
    {
        public List<PaymentMethod> GetAllPaymentMethods()
        {
            //For test purposes we just list a few payment methods
            var methods = new List<PaymentMethod>();
            methods.Add(new PaymentMethod { Method = "Credit Card" });
            methods.Add(new PaymentMethod { Method = "Cash on Delivery" });
            methods.Add(new PaymentMethod { Method = "Invoice" });

            return methods;
        }
    }
}
