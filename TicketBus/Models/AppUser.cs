using Microsoft.AspNetCore.Identity;
using TicketBus.Data.Enum;

namespace TicketBus.Models
{
    public class AppUser : IdentityUser
	{
		public string? FullName { get; set; }
		public string Role { get; set; }
        public string? ProfileImageUrl { get; set; }
        public ICollection<TicketInfo> ticketInfos { get; set; }
	}
}
