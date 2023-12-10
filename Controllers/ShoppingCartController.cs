//using System;
//using System.Collections.Generic;
//using System.Dynamic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using WebApplication2.Models;

//namespace WebApplication2.Controllers
//{
//    public class ShoppingCartController : Controller
//    {
//        // GET: ShoppingCart
//        public ActionResult Index()
//        {
//            return View();
//        }
//        public ActionResult Order()
//        {
//            return View();
//        }
//        public ActionResult Details()
//        {
//            return View();
//        }
//        public Cart GetCart()
//        {
//            Cart cart = Session["Cart"] as Cart;
//            if (cart == null || Session["Cart"] == null)
//            {
//                cart = new Cart();
//                Session["Cart"] = cart;

//            }
//            return cart;
//        }
//        public ActionResult AddtoCart(int ID)
//        {
//            var inside = db.Tour_Inside.SingleOrDefault(s => s.ID_tour_inside == ID);
//            if (inside != null)
//            {
//                GetCart().Add(inside);
//            }

//            return RedirectToAction("Show", "ShoppingCart");

//        }
//        public ActionResult Show()
//        {
//            if (Session["Cart"] == null)
//            {
//                return RedirectToAction("Show", "ShoppingCart");
//            }
//            Cart cart = Session["Cart"] as Cart;

//            return View(cart);
//        }
//        public ActionResult Update_Quantity_Cart(FormCollection form)
//        {
//            Cart cart = Session["Cart"] as Cart;
//            int id = int.Parse(form["ID_tour_inside"]);

//            int quantity = int.Parse(form["Quantity"]);

//            cart.Update_Quanlity_Shopping(id, quantity);
//            return RedirectToAction("Show", "ShoppingCart");
//        }
//        public ActionResult doo()
//        {

//            return View();

//        }
//        public ActionResult Payment()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Payment(string Cus_Name, string service_name)
//        {
//            try
//            {
//                Cart cart = Session["Cart"] as Cart;
//                Order order = new Order();
//                order.Order_date = DateTime.Now.ToString();
//                order.Cus_Name = Cus_Name;
//                order.service_name = service_name;
//                db.Orders.Add(order);
//                foreach (var item in cart.Items)
//                {
//                    Orderdetail orderdetail = new Orderdetail();
//                    orderdetail.ID_order = order.ID_order;
//                    orderdetail.Name_ticket = item.inside.Name_ticket;
//                    orderdetail.Total_price = item.inside.Price;


//                }
//                db.SaveChanges();
//                cart.clearCart();

//                return RedirectToAction("doo", "ShoppingCart");


//            }
//            catch
//            {
//                return Content("error");

//            }
//        }
//        public ActionResult Test()
//        {
//            var model = new CartView().lala().ToList();
//            var model1 = new CartView().lalo().ToList();

//            dynamic mymodel = new ExpandoObject();
//            mymodel.Model = model;
//            mymodel.Model1 = model1;
//            return View(mymodel);
//        }

//    }

//}
//}