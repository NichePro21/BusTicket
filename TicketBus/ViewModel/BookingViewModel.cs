using System.ComponentModel.DataAnnotations;

namespace TicketBus.ViewModel
{
    public class BookingViewModel
    {
        public int TicketNumber { get; set; }

        public string CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerPhone { get; set; }

        public string BusName { get; set; }

        public TimeSpan start_time { get; set; }

        public TimeSpan end_time { get; set; }

        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public int Distance { get; set; }

        public string StartDate { get; set; }

        public int TicketAdult { get; set; }

        public int TicketChild { get; set; }

        public int TicketNomarl { get; set; }

        [Display(Name = "Ticket Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "The value must be greater to 0.")]
        public int TicketQuantity { get; set; }

        public decimal Total { get; set; }

        public decimal Subtotal { get; set; }

        public decimal Discount { get; set; }

        public decimal Price { get; set; }

        public string OrderDate { get; set; }
    }
}
