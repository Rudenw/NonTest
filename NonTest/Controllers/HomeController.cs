using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NonTest.Models;
using NonTest.Services;
using System.Threading.Tasks;

namespace NonTest.Controllers
{
    public class HomeController : Controller
    {
        private OrderPlacementManager _orderPlacer;
        private OrderListManager _orderLister;
        private OrderPlacementViewModel _order;

        public HomeController()
        {
            _orderPlacer = new OrderPlacementManager();
            _orderLister = new OrderListManager();
            _order = _orderPlacer.GetOrderPlacement();
        }

        public ActionResult Index()
        {
            if (Session["cart"] == null)
            {
                Session["cart"] = _order.ShoppingCart;
            }
            else
            {
                _order.ShoppingCart = Session["cart"] as ShoppingCartViewModel;
            }

            return View(_order);
        }

        [HttpPost]
        public ActionResult Add(ProductViewModel product)
        {
            if (Session["cart"] != null)
            {
                _order.ShoppingCart = Session["cart"] as ShoppingCartViewModel;
            }
            _order.ShoppingCart.Rows = _orderPlacer.UpdateCartRowsFromProduct(product, _order.ShoppingCart.Rows);
            _orderPlacer.UpdateCartValues(_order.ShoppingCart);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlaceOrder(OrderPlacementViewModel placeOrder)
        {
            placeOrder.ShoppingCart = Session["cart"] as ShoppingCartViewModel;
            Session["cart"] = null;

            _orderPlacer.PlaceOrder(placeOrder);

            return RedirectToAction("Index");
        }

        public ActionResult OrderList()
        {
            ViewBag.Message = "Order List";

            var orders = _orderLister.GetOrders();

            return View(orders);
        }
    }
}