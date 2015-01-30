using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NonTestRepository.Entities;

namespace NonTestRepository
{
    public class OrderRepository
    {
        public List<Order> GetAllOrders()
        {
            var files = Directory.GetFiles(@"Orders\", "*.xml");
            var orders = new List<Order>();

            foreach (string file in files)
            {
                try
                {
                    var xml = File.ReadAllText(file);
                    XmlSerializer serializer = new XmlSerializer(typeof(Order));
                    orders.Add((Order)serializer.Deserialize(new StringReader(xml))); 
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return orders;
        }

        public void PlaceOrder(Order order)
        {
            if (!Directory.Exists("Orders"))
                Directory.CreateDirectory("Orders");
            XmlSerializer xml = new XmlSerializer(order.GetType());
            StreamWriter stream = new StreamWriter(@"Orders\Order_" + DateTime.Now.ToString("yyyy_MM_dd_hhmmssfff") + ".xml");
            xml.Serialize(stream, order);
            
            stream.Close();
        }
    }
}
