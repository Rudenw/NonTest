using System.Collections.Generic;
using System.Linq;
using NonTest.Models;
using NonTestRepository.Entities;
using NonTestRepository.Repositories;

namespace NonTest.Services.Mappers
{
    public class OrderPlacementMapper : EntityMapper
    {
        public Order MapViewModelToOrder(OrderPlacementViewModel placeOrder, CountryRepository countryRepository, ProductRepository productRepository)
        {
            var order = new Order {BillingAddress = MapViewModelToAddress(placeOrder.BillingAddress, countryRepository)};
            order.ShipToAddress = placeOrder.UseShipToAddress ? MapViewModelToAddress(placeOrder.ShipToAddress, countryRepository) : order.BillingAddress;
            order.PaymentMethod = placeOrder.ChosenPaymentMethod;

            order.OrderLines = MapShoppingCartToOrderLines(placeOrder.ShoppingCart, productRepository);

            return order;
        }

        private List<OrderLine> MapShoppingCartToOrderLines(ShoppingCartViewModel shoppingCart, ProductRepository productRepository)
        {
            var orderLines = new List<OrderLine>();
            int orderRowCounter = 10;
            foreach (ShoppingCartRowViewModel row in shoppingCart.Rows)
            {
                var orderLine = new OrderLine
                {
                    Quantity = row.ProductQuantity,
                    Product = GetProductFromViewModel(row.Product, productRepository),
                    Value = row.Value,
                    OrderRow = orderRowCounter
                };

                orderLines.Add(orderLine);

                orderRowCounter += 10;
            }

            var freightRow = new OrderLine
            {
                OrderRow = orderRowCounter,
                Quantity = 1,
                Value = shoppingCart.FreightCost,
                Product = productRepository.GetFreightCost(shoppingCart.FreightCost)
            };

            orderLines.Add(freightRow);

            return orderLines;
        }

        private Address MapViewModelToAddress(AddressViewModel addressViewModel, CountryRepository countryRepository)
        {
            var address = new Address
            {
                FirstName = addressViewModel.FirstName,
                LastName = addressViewModel.LastName,
                StreetAddress = addressViewModel.Address,
                PostalCode = addressViewModel.PostalCode,
                City = addressViewModel.City,
                Country = countryRepository.GetCountryFromIsoCode(addressViewModel.IsoCountry)
            };

            return address;
        }

        private Product GetProductFromViewModel(ProductViewModel productViewModel, ProductRepository productRepository)
        {
            return productRepository.GetProductFromId(productViewModel.ProductId);
        }
    }
}