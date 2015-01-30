using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NonTest.Models;
using NonTest.Services.Mappers;
using NonTestRepository;

namespace NonTest.Services
{
    public class OrderListManager
    {
        private readonly OrderRepository _orderRepository;
        private readonly OrderListMapper _mapper;

        public OrderListManager()
        {
            _orderRepository = new OrderRepository();
            _mapper = new OrderListMapper();
        }

        public List<OrderViewModel> GetOrders()
        {
            var orders = _orderRepository.GetAllOrders();

            return orders.Select(order => _mapper.MapOrderToViewModel(order)).ToList();
        }
    }
}