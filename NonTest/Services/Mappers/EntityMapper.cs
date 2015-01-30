using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NonTest.Models;
using NonTestRepository.Entities;

namespace NonTest.Services.Mappers
{
    public class EntityMapper
    {
        public ProductViewModel MapProductToViewModel(Product product)
        {
            var viewModelProduct = new ProductViewModel
            {
                ProductId = product.Id,
                Name = product.Name,
                Brand = product.Brand,
                Model = product.Model,
                Price = product.Price
            };

            var products = product.Products.Select(MapProductToViewModel).ToList();

            viewModelProduct.Products = products;
            viewModelProduct.BundleItem = product.BundleItem;

            return viewModelProduct;
        }

        public CountryViewModel MapCountryToViewModel(Country country)
        {
            var viewModel = new CountryViewModel { IsoCode = country.ISOCode, DisplayName = country.Name };

            return viewModel;
        }
    }
}