using System.ComponentModel.DataAnnotations;

namespace TicketBus.Models
{
	public class Routes
	{
		
		public int id { get; set; }

		public string? start_point { get; set; }
		
		public string? end_point { get; set; }
		
		//donvi tinh km
		public int distance { get; set; }
		
		public string? description { get; set; }

		

        public ICollection<BusRoute> BusRoute { get; set; }

	}
}
