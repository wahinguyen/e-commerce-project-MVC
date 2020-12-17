using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopQuanAo.Models;
using PayPal.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using PayPal.v1.Payments;
using Microsoft.AspNetCore.Http;
using Order = ShopQuanAo.Models.Order;
using BraintreeHttp;
using Microsoft.AspNetCore.Identity;

namespace ShopQuanAo.Controllers
{
    public class CartController : Controller
    {
        private readonly SaleContext db;
        private readonly string _clientId;
        private readonly string _secretKey;
        private readonly UserManager<User> _userManager;

        public double TyGiaUSD = 23300;

        public CartController(UserManager<User> userManager, SaleContext db, IConfiguration configuration)
        {
            this.db = db;
            _userManager = userManager;
            _clientId = configuration["PaypalSettings:ClientId"];
            _secretKey = configuration["PaypalSettings:SecretKey"];
        }

        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            if (cart == null)
                return View();
            else
            {
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => item.SanPham.DonGia * item.SoLuong);
                ViewBag.count = cart.Count();
            }
            return View();
        }

        public IActionResult GioHang()
        {

            var cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");

            if (cart == null)
                return View();
            else
            {
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => item.SanPham.DonGia * item.SoLuong);
                ViewBag.final = cart.Sum(item => item.ThanhTien) - cart.Select(item => item.GiaGiam).FirstOrDefault();
                ViewBag.voucher = cart.Select(item => item.GiaGiam).FirstOrDefault();
                ViewBag.count = cart.Count();
            }
            return View();
        }

        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {
            
            if (SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart") == null)
            {
                List<OrderDetail> cart = new List<OrderDetail>
            {
                new OrderDetail { SanPham = db.Sanphams.FirstOrDefault(p => p.MaSP == id), SoLuong = 1, ThanhTien = db.Sanphams.Where(p => p.MaSP == id).Select(p => p.DonGia).FirstOrDefault()}
            };
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<OrderDetail> cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
                int index = IsExist(id);
                if (index != -1)
                    cart[index].SoLuong++;
                else
                    cart.Add(new OrderDetail { SanPham = db.Sanphams.FirstOrDefault(p => p.MaSP == id), SoLuong = 1, ThanhTien = db.Sanphams.Where(p => p.MaSP == id).Select(p => p.DonGia).FirstOrDefault()});
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("GioHang");
            
        }
        [HttpPost]
        public IActionResult Update(int MaSP, int txtSoLuong)
        {
            List<OrderDetail> cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            int index = IsExist(MaSP);
            cart[index].SoLuong = txtSoLuong;
            cart[index].ThanhTien = cart[index].SanPham.DonGia * cart[index].SoLuong;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return RedirectToAction("GioHang");
        }

        [HttpPost]
        public IActionResult AddDiscount(string qrCode)
        {
            List<OrderDetail> cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            var discount = db.Discount
                .AsEnumerable()
                .Where(d => d.QRCode == qrCode && d.DateExpired >= DateTime.Now)
                .Any();

            if (discount)
            {
                double amountDiscount = db.Discount.Where(d => d.QRCode == qrCode).Select(d => d.Amount).FirstOrDefault();
                cart.ForEach(s => s.ThanhTien = s.SanPham.DonGia * s.SoLuong);
                cart.ForEach(s => s.GiaGiam = amountDiscount);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                return RedirectToAction("GioHang");
            }
            else
            {
                throw new Exception("Mã đã hết hạn hoặc không tồn tại");
            }
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<OrderDetail> cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            int index = IsExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("GioHang");
        }
        private int IsExist(int id)
        {
            List<OrderDetail> cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].SanPham.MaSP == id)
                {
                    return i;
                }
            }
            return -1;
        }
        public IActionResult Confirm()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            if (User.Identity.IsAuthenticated)
            {
                var name = User.Identity.Name;
                var user = await _userManager.FindByNameAsync(name);
                var cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
                if (cart == null)
                    return View();
                else
                {
                    ViewBag.cart = cart;
                    ViewBag.total = cart.Sum(item => item.SanPham.DonGia * item.SoLuong);
                    ViewBag.voucher = cart.Select(item => item.GiaGiam).FirstOrDefault();
                    ViewBag.final = cart.Sum(item => item.ThanhTien) - cart.Select(item => item.GiaGiam).FirstOrDefault();
                }
                Order order = new Order()
                {
                    CustomerName = user.FirstName + " " + user.LastName,
                    Email = user.Email,
                    Phone = user.PhoneNumber,
                };
                return View(order);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(Order order)
        {
            if (ModelState.IsValid)
            {

                var name = User.Identity.Name;
                var user = await _userManager.FindByNameAsync(name);

                double discount = 0;
                var codePrefix = DateTime.Now.ToString("ddMMyyyy");

                var maxOrderCount = db.Orders
                    .Where(e => e.Code.Contains(codePrefix))
                    .Count();

                maxOrderCount += 1;
                string orderCode = String.Format("{0:D4}", maxOrderCount);

                var code = String.Format("{0}-{1}", codePrefix, orderCode);

                List<OrderDetail> cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");

                discount = cart.Select(item => item.GiaGiam).FirstOrDefault();

                Order orderTemp = new Order
                {
                    Code = code,
                    KhachHang = user.Email,
                    OrderDate = DateTime.Now,
                    Phone = order.Phone,
                    Address = order.Address,
                    Email = order.Email,
                    CustomerName = order.CustomerName,
                    GiaGiam = discount,
                    StatusID = 0,
                };
                db.Orders.Add(orderTemp);
                db.SaveChanges();

                var query = db.Orders.FirstOrDefault(p => p.OrderId == orderTemp.OrderId);
                foreach (var item in cart)
                {
                    db.OrderDetails.Add(new OrderDetail()
                    {
                        OrderId = query.OrderId,
                        MaSP = item.SanPham.MaSP,
                        SoLuong = item.SoLuong,
                        ThanhTien = item.SanPham.DonGia * item.SoLuong,
                    });

                    var product = db.Sanphams
                        .AsEnumerable()
                        .Where(s => s.MaSP == item.SanPham.MaSP)
                        .FirstOrDefault();

                    if (product != null)
                    {
                        product.SoLuong = product.SoLuong - item.SoLuong;
                    }

                    orderTemp.Total += item.ThanhTien; 
                }
                ViewBag.total1 = orderTemp.Total = orderTemp.Total - discount;
                db.SaveChanges();
                cart.Clear();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                return RedirectToAction("Confirm", "Cart");
            }
            return View(order);
        }

        public async System.Threading.Tasks.Task<IActionResult> PaypalCheckout()
        {
            var environment = new SandboxEnvironment(_clientId, _secretKey);
            var client = new PayPalHttpClient(environment);
            List<OrderDetail> listCarts = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            #region Create Paypal Order
            var itemList = new ItemList()
            {
                Items = new List<Item>()
            };

            var total = Math.Round(listCarts.Sum(p => p.ThanhTien) / TyGiaUSD, 2);
            foreach (var item in listCarts)
            {
                itemList.Items.Add(new Item()
                {
                    Name = item.SanPham.TenSP,
                    Currency = "USD",
                    Price = "10000",
                    Quantity = "2",
                    Sku = "sku",
                    Tax = "0"
                });
            }
            #endregion

            var paypalOrderId = DateTime.Now.Ticks;
            //var hostname = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            var payment = new Payment()
            {
                Intent = "sale",
                Transactions = new List<Transaction>()
                {
                    new Transaction()
                    {
                        Amount = new Amount()
                        {
                            Total = "10000",
                            Currency = "USD",
                            Details = new AmountDetails
                            {
                                Tax = "0",
                                Shipping = "0",
                                Subtotal = total.ToString()
                            }
                        },
                        ItemList = itemList,
                        Description = $"Invoice #{paypalOrderId}",
                        InvoiceNumber = paypalOrderId.ToString()
                    }
                },
                RedirectUrls = new RedirectUrls()
                {
                    CancelUrl = $"",
                    ReturnUrl = $""
                },
                Payer = new Payer()
                {
                    PaymentMethod = "paypal"
                }
            };
            PaymentCreateRequest request = new PaymentCreateRequest();
            request.RequestBody(payment);

            try
            {
                var response = await client.Execute(request);
                var statusCode = response.StatusCode;
                Payment result = response.Result<Payment>();

                var links = result.Links.GetEnumerator();
                string paypalRedirectUrl = null;
                while (links.MoveNext())
                {
                    LinkDescriptionObject lnk = links.Current;
                    if (lnk.Rel.ToLower().Trim().Equals("approval_url"))
                    {
                        //saving the payapalredirect URL to which user will be redirected for payment  
                        paypalRedirectUrl = lnk.Href;
                    }
                }

                return Redirect(paypalRedirectUrl);
            }
            catch (HttpException httpException)
            {
                var statusCode = httpException.StatusCode;
                var debugId = httpException.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();

                //Process when Checkout with Paypal fails
                return Redirect("/GioHang/CheckoutFail");
            }
        }

        public IActionResult CheckoutFail()
        {
            //Tạo đơn hàng trong database với trạng thái thanh toán là "Chưa thanh toán"
            //Xóa session
            return View("Chưa thanh toán");
        }

        public IActionResult CheckoutSuccess()
        {
            //Tạo đơn hàng trong database với trạng thái thanh toán là "Paypal" và thành công
            //Xóa session
            return View("thành công");
        }
    }
}