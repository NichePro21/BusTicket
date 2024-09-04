using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

using TicketBus.Data;
using TicketBus.Models;
using TicketBus.ViewModel;

namespace TicketBus.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;
		public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
		{
			_logger = logger;
			_context = context;
		}

        public IActionResult Index()
        {
            List<Routes> startPoints = _context.Routes
                                                .GroupBy(r => r.start_point)
                                                .Select(group => new Routes { start_point = group.Key })
                                                .Distinct()
                                                .ToList();

            return View(startPoints);
        }


        public IActionResult GetEndPoints(string startPoint)
        {
            var endPoints = _context.Routes
                                    .Where(r => r.start_point == startPoint)
                                    .Select(r => new { r.id, r.end_point }) // Select both route_name and end_point
                                    .ToList();

            if (endPoints.Count == 0)
            {
                // Nếu không có điểm đích phù hợp hoặc điểm xuất phát không hợp lệ, 
                // trả về một danh sách chứa một phần tử với nội dung thông báo
                return Json(new List<string> { "No matching destination found." });
            }

            return Json(endPoints);
        }
        public IActionResult Privacy()
		{
			return View();
		}
/*
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
        public IActionResult SelectStartPoints()
        {
            List<Routes> startPoints = GetStartPointsFromDatabase();
            return View(startPoints);
        }

        // Hàm này lấy dữ liệu từ cơ sở dữ liệu và trả về danh sách các phần tử trong cột "start_point"
        private List<Routes> GetStartPointsFromDatabase()
        {
            // Trong thực tế, bạn cần thay thế phần này bằng cách lấy dữ liệu từ cơ sở dữ liệu của bạn.
            // Ở đây, ta chỉ mô phỏng dữ liệu tạm thời bằng cách tạo một danh sách cố định.

            string startPointsString = "Công trường Mê Linh - Đường Thi Sách - Công trường Mê Linh - Đường Tôn Đức Thắng - Đường Hàm Nghi - Đường Trần Hưng Đạo - Đường Nguyễn Tri Phương - Đường Trần Phú - Đường Trần Hưng Đạo - Đường Châu Văn Liêm - Đường Hải Thượng Lãn Ông - Đường Trang Tử - Bến xe buýt Chợ Lớn (Bến A)";
            string[] startPointsArray = startPointsString.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

            List<Routes> startPoints = new List<Routes>();
            foreach (string startPoint in startPointsArray)
            {
                startPoints.Add(new Routes { start_point = startPoint });
            }

            return startPoints;
        }*/
    }
}