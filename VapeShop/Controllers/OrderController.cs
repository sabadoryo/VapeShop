using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using VapeShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VapeShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        // GET: /<controller>/
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first");
            }

            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(order.Email);
                mail.From = new MailAddress("eabilbay@gmail.com", "VapeShop", System.Text.Encoding.UTF8);
                mail.Subject = "Thank you for choosing our vape shop";
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                decimal total = 0;
                string koko = String.Format("<strong>Hi,{0}{1} </strong>", order.FirstName, order.LastName) +"<br>";
                foreach (ShoppingCartItem p in items) {
                    total += p.Vape.Price;
                    koko += p.Vape.Name + ":   " + p.Vape.Price + "$<br>";
                }
                mail.Body = String.Format("<strong>Hi,{0}{1} </strong>", order.FirstName, order.LastName) + "<br>" + "Your ordered items:<br>" + koko;
                string footer_message = "<br>Your total is:   " + total + "$<br>";
                string user_info = "<br>Your data: <br>" + order.AddressLine1 + "<br>"+ order.City + "<br>" + order.Country + "<br>" + order.PhoneNumber;
                mail.Body += footer_message + user_info;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("eabilbay@gmail.com", "svhuknaseqyauqlf");
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                try
                {
                    client.Send(mail);
                }
                catch (Exception ex)
                {
                    Exception ex2 = ex;
                    string errorMessage = string.Empty;
                    while (ex2 != null)
                    {
                        errorMessage += ex2.ToString();
                        ex2 = ex2.InnerException;
                    }
                }
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy our delicious pies!";
            return View();
        }
    }
}
