using Microsoft.AspNetCore.Identity;
using Top_Fashion.TopFashion.Domain.Entities;

namespace Top_Fashion.TopFashion.Infrastructure.Data.Config
{
    public class IdentitySeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                //create new user
                var user = new AppUser
                {
                    DisplayName = "Akl",
                    Email = "A7medAkl@gmail.com",
                    UserName = "A7medAkl",
                    Address = new Address
                    {
                        FirstName = "Ahmed",
                        LastName = "Akl",
                        City = "Cairo",
                        State = "Shubra City",
                        Street = "Street Eltabona",
                        ZipCode = "6221101"

                    }
                };
                await userManager.CreateAsync(user, "P@$$w0rd");
            }
        }
    }
}
