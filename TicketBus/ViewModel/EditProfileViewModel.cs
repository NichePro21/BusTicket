namespace TicketBus.ViewModel
{
    public class EditProfileViewModel
    {
        public int Id { get; set; }
        public string ProfileImageUrl { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile? Image { get; set; }
    }
}
