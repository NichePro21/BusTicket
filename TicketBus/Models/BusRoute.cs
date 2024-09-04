using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketBus.Models
{
	public class BusRoute
	{
	
        public int id { get; set; }
        
        public int bus_id { get; set; }
        
        public int route_id { get; set; }
       
        public TimeSpan start_time { get; set; }

        public TimeSpan end_time { get; set; }

        public string StartDate { get; set; }

        public decimal Price { get; set; }

        public int SeatsAvailable { get; set; }

        public Routes Routes { get; set; }

        public Buses Buses { get; set; }
    }
}
