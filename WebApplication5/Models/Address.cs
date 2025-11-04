using Microsoft.AspNetCore.Identity;

namespace WebApplication5.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string AdressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
    }
}
