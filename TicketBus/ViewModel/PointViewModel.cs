using TicketBus.Models;

namespace TicketBus.ViewModel
{
    public class PointViewModel
    {
        public int id { get; set; }

        public int bus_id { get; set; }

        public string bus_name { get; set; }

        public int route_id { get; set; }

        public TimeSpan start_time { get; set; }

        public string  StartDate { get; set; }

        public TimeSpan end_time { get; set; }

        public string start_point { get; set; }

        public string end_point { get; set; }

        public decimal price { get; set; }

        public int distance { get; set; }

        public string description { get; set; }

        public int SeatsAvailable { get; set; }

        public string CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerPhone { get; set; }
    }
}
