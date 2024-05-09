using Microsoft.AspNetCore.Identity;

namespace Top_Fashion.TopFashion.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public Address Address { get; set; }
    }
}
