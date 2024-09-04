namespace TicketBus.ViewModel
{
    public class WelcomeViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? ProfileImageUrl { get; set; }
        public IFormFile? Image { get; set; }
    }
}
