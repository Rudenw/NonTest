using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NonTest.Models;
using NonTest.Services.Mappers;
using NonTestRepository;
using NonTestRepository.Repositories;

namespace NonTest.Services
{
    public class OrderPlacementManager
    {
        private readonly ProductRepository _productRepository;
        private readonly CountryRepository _countryRepository;
        private readonly PaymentMethodRepository _paymentMethodsRepository;
        private readonly OrderRepository _orderRepository;
        private readonly OrderPlacementMapper _mapper;

        public OrderPlacementManager()
        {
            _orderRepository = new OrderRepository();
            _productRepository = new ProductRepository();
            _countryRepository = new CountryRepository();
            _paymentMethodsRepository = new PaymentMethodRepository();

            _mapper = new OrderPlacementMapper();
        }

        public List<CountryViewModel> GetCountries()
        {
            var countries = _countryRepository.GetAllCountries();

            return countries.Select(_mapper.MapCountryToViewModel).ToList();
        }

        public OrderPlacementViewModel GetOrderPlacement()
        {
            var order = new OrderPlacementViewModel();
            var countries = GetCountries();

            order.Products = GetProducts();
            order.ShoppingCart = GetEmptyShoppingCart();

            order.ShipToAddress = new AddressViewModel {Countries = new SelectList(countries, "IsoCode", "DisplayName")};
            order.BillingAddress = new AddressViewModel
            {
                Countries = new SelectList(countries, "IsoCode", "DisplayName")
            };

            order.PaymentMethods = GetPaymentMethods();

            return order;
        }

        private List<string> GetPaymentMethods()
        {
            var methods = _paymentMethodsRepository.GetAllPaymentMethods();

            return methods.Select(method => method.Method).ToList();
        }

        private ShoppingCartViewModel GetEmptyShoppingCart()
        {
            var cart = new ShoppingCartViewModel {Rows = new List<ShoppingCartRowViewModel>()};
            return cart;
        }

        public List<ProductViewModel> GetProducts()
        {
            var mainProducts = _productRepository.GetAllProducts();

            return mainProducts.Select(product => _mapper.MapProductToViewModel(product)).ToList();
        }

        public List<ShoppingCartRowViewModel> UpdateCartRowsFromProduct(ProductViewModel product, List<ShoppingCartRowViewModel> rows)
        {
            var row = rows.FirstOrDefault(x => x.Product.ProductId.Equals(product.ProductId));

            if (row != null)
            {
                row.ProductQuantity += product.Quantity;
                row.Value = row.ProductQuantity * product.Price;
            }
            else
            {
                row = new ShoppingCartRowViewModel {Product = product, ProductQuantity = product.Quantity};
                row.Value = row.ProductQuantity * product.Price;

                rows.Add(row);
            }

            return rows;
        }

        public void UpdateCartValues(ShoppingCartViewModel cart)
        {
            int freightCost = 49;

            freightCost += 50 * (cart.Rows.Sum(x => x.ProductQuantity) - 1);

            cart.FreightCost = freightCost;
            cart.TotalValue = cart.Rows.Sum(x => x.Value) + cart.FreightCost;
        }

        public void PlaceOrder(OrderPlacementViewModel placeOrder)
        {
            var order = _mapper.MapViewModelToOrder(placeOrder, _countryRepository, _productRepository);
            order.OrderValue = order.OrderLines.Sum(x => x.Value);

            _orderRepository.PlaceOrder(order);
        }
    }
}