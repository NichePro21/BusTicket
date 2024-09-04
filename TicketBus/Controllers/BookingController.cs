using Microsoft.AspNetCore.Mvc;
using TicketBus.ViewModel;
using System;
using System.Web;
using Microsoft.EntityFrameworkCore;
using TicketBus.Data;
using TicketBus.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace TicketBus.Controllers
{
    public class BookingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _context;
        public BookingController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(PointViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                // Bạn có thể truy cập thông tin của người dùng ở đây
                var fullname = user.FullName;
                var email = user.Email;
                var phone = user.PhoneNumber;
                var id = user.Id;

                // Thay vì tạo một đối tượng mới, bạn có thể chỉnh sửa đối tượng được truyền vào
                // Chắc chắn rằng đối tượng model không phải là null trước khi thực hiện việc này
                if (model != null)
                {
                    model.CustomerName = fullname; // Gán thông tin vào đối tượng model
                    model.CustomerEmail = email;
                    model.CustomerPhone = phone;
                    model.CustomerId = id;
                    return View(model); // Trả về view với đối tượng model
                }

                // Nếu model là null, bạn có thể xử lý theo cách phù hợp
                return NotFound();
            }

            // Nếu người dùng không đăng nhập, bạn có thể xử lý theo cách phù hợp
            return Redirect("/Account/Login"); // Hoặc Redirect tới trang đăng nhập
        }
          [HttpPost]
        public IActionResult BookTicket(BookingViewModel model)
        {
            var booking = new BookingViewModel();
            booking = model;

            return RedirectToAction("Confirmation", booking);
        }

        /* public IActionResult BookTicket(BookingViewModel model)
         {
             // Gọi action Confirmation và truyền thông tin qua đối tượng ticketInfo
             return RedirectToAction("Confirmation", "Booking");
         }*/

        public ActionResult Confirmation(TicketInfo ticketInfo)
        {
           //InsertTicketInfo(ticketInfo);
            return View(ticketInfo);
        }
       // [HttpPost]
        public async Task<IActionResult> InsertTicketInfo([FromBody] TicketInfo ticketInfo)
        {
            try
            {
                // Assuming TicketNumber is auto-generated in the database, so we exclude it when adding to the database
                var newTicket = new TicketInfo
                {
                    CustomerName = ticketInfo.CustomerName,
                    CustomerEmail = ticketInfo.CustomerEmail,
                    CustomerPhone = ticketInfo.CustomerPhone,
                    CustomerId = ticketInfo.CustomerId,
                    TicketNumber = ticketInfo.TicketNumber,
                    BusName = ticketInfo.BusName,
                    start_time = ticketInfo.start_time,
                    end_time = ticketInfo.end_time,
                    StartPoint = ticketInfo.StartPoint,
                    EndPoint = ticketInfo.EndPoint,
                    Distance = ticketInfo.Distance,
                    StartDate = ticketInfo.StartDate,
                    TicketAdult = ticketInfo.TicketAdult,
                    TicketChild = ticketInfo.TicketChild,
                    TicketNomarl = ticketInfo.TicketNomarl,
                    TicketQuantity = ticketInfo.TicketQuantity,
                    Total = ticketInfo.Total,
                    Subtotal = ticketInfo.Subtotal,
                    Discount = ticketInfo.Discount,
                    Price = ticketInfo.Price,
                    AppUserId = ticketInfo.CustomerId,
                    OrderDate = DateTime.Now
                };

                // Add the new ticket to the database
                _context.Add(newTicket);
                await _context.SaveChangesAsync();

                return Ok(newTicket); // Return the inserted ticket as a response
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                return BadRequest(ex.Message);
            }
        }
        public ActionResult SubmitTicket(TicketInfo ticketInfo)
        {
            // Thực hiện việc chèn thông tin vé vào cơ sở dữ liệu
            InsertTicketInfo(ticketInfo);

            // Chuyển hướng đến trang ordersuccess
            return RedirectToAction("OrderSuccess");
        }
        public ActionResult OrderSuccess()
        {
            return View();
        }



    }
}
