using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using TicketBus.Data;
using TicketBus.Models;
using TicketBus.ViewModel;

namespace TicketBus.Controllers
{
    public class BusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BusController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var buses = await _context.Buses.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetBus(string startPoint, string endPointSelect, string ngaydi)
        {
            var routes = from r in _context.Routes
                         join rd in _context.BusRoutes on r.id equals rd.route_id into prd
                         from rd in prd.DefaultIfEmpty()
                         join b in _context.Buses on rd.bus_id equals b.id into rdb
                         from b in rdb.DefaultIfEmpty()
                         where r.start_point == startPoint && r.end_point == endPointSelect && rd.StartDate == ngaydi
                         select new { b, rd, r };

            var data = routes.Select(x => new PointViewModel()
            {
                bus_id = x.rd.bus_id,
                bus_name = x.b.bus_name,
                start_time = x.rd.start_time,
                end_time = x.rd.end_time,
                price = x.rd.Price,
                SeatsAvailable = x.rd.SeatsAvailable,
                distance = x.r.distance,
                start_point = startPoint,
                end_point = endPointSelect,
                StartDate = ngaydi,

            }).ToList();

            //var bus = await _context.Buses.ToListAsync();


            return View(data);
        }










    }
}
