using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NonTest.Models;
using NonTestRepository.Entities;

namespace NonTest.Services.Mappers
{
    public class OrderListMapper : EntityMapper
    {


        public OrderViewModel MapOrderToViewModel(Order order)
        {
            var orderModel = new OrderViewModel
            {
                ShipToAddress = MapAddressToViewModel(order.ShipToAddress),
                PaymentMethod = order.PaymentMethod,
                OrderValue = order.OrderValue
            };
            orderModel.OrderLines = MapOrderLinesToViewModels(order.OrderLines);

            return orderModel;
        }

        private List<OrderLineViewModel> MapOrderLinesToViewModels(List<OrderLine> orderLines)
        {
            return orderLines.Select(line => new OrderLineViewModel
            {
                OrderRow = line.OrderRow,
                Quantity = line.Quantity,
                Product = MapProductToViewModel(line.Product),
                Value = line.Value
            }).ToList();
        }

        private AddressViewModel MapAddressToViewModel(Address address)
        {
            var addressModel = new AddressViewModel();
            addressModel.FirstName = address.FirstName;
            addressModel.LastName = address.LastName;
            addressModel.Address = address.StreetAddress;
            addressModel.PostalCode = address.PostalCode;
            addressModel.City = address.City;
            addressModel.Country = address.Country.Name;

            return addressModel;
        }
    }
}