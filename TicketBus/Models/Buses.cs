using System.ComponentModel.DataAnnotations;

namespace TicketBus.Models
{
	public class Buses
	{
		
		public int id { get; set; }
		
		public string? image { get; set; }

		public string? bus_number { get; set; }

		public string? bus_name { get; set; }

		public ICollection<BusRoute> BusRoutes { get; set; }

	}
}
