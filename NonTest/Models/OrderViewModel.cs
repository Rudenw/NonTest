using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web.Mvc;

namespace NonTest.Models
{
    public class OrderViewModel
    {
        public AddressViewModel ShipToAddress { get; set; }

        [Display(Name = "Method of Payment")]
        public string PaymentMethod { get; set; }

        [Display(Name = "Cost")]
        public double OrderValue { get; set; }

        public List<OrderLineViewModel> OrderLines { get; set; }
    }

    public class OrderLineViewModel
    {
        [Display(Name = "Row")]
        public int OrderRow { get; set; }

        [Display(Name = "Amount")]
        public int Quantity { get; set; }

        public ProductViewModel Product { get; set; }

        [Display(Name = "Cost")]
        public double Value { get; set; }
    }

    public class OrderPlacementViewModel
    {
        public List<ProductViewModel> Products { get; set; }

        public ShoppingCartViewModel ShoppingCart { get; set; }

        public AddressViewModel BillingAddress { get; set; }

        [Display(Name = "Send to someone else")]
        public bool UseShipToAddress { get; set; }

        public AddressViewModel ShipToAddress { get; set; }

        [Display(Name = "Methods of Payment")]
        public List<string> PaymentMethods { get; set; }

        [Required]
        [Display(Name = "Method of Payment")]
        public string ChosenPaymentMethod { get; set; }
    }

    public class ShoppingCartViewModel
    {
        public List<ShoppingCartRowViewModel> Rows { get; set; }
        
        [Display(Name = "Freight Cost")]
        public double FreightCost { get; set; }

        [Display(Name = "Total Sum")]
        public double TotalValue { get; set; }
    }

    public class ShoppingCartRowViewModel
    {
        public int ProductQuantity { get; set; }

        public ProductViewModel Product { get; set; }

        public double Value { get; set; }
    }

    public class AddressViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "City")]
        public string City { get; set; }

        public string IsoCountry { get; set; }
        public string Country { get; set; }

        public SelectList Countries { get; set; }
    }

    public class CountryViewModel
    {
        public string IsoCode { get; set; }
        public string DisplayName { get; set; }
    }

    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public double Price { get; set; }

        public List<ProductViewModel> Products;
        public bool BundleItem;
    }
}