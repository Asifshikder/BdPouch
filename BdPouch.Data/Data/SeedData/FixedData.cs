using BdPouch.Core.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Data.Data.SeedData
{
    public class FixedData
    {
        public static void SeedData(ModelBuilder builder)
        {

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7222", Name = "Admin", NormalizedName = "ADMIN" }
                );

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "5f72f83b-7436-4221-869c-1b69b2e23aae",
                    PhoneNumber = "01811499160",
                    Email = "admin@bdpouch.com",
                    EmailConfirmed = true,
                    FullName = "System Admin",
                    LockoutEnabled = false,
                    NormalizedEmail = "ADMIN@BDPOUCH.UK",
                    NormalizedUserName = "ADMINISTRATOR",
                    PasswordHash = "AQAAAAEAACcQAAAAEG5RAeb9u5cUMs6+gMEObzW1vDND9HX9Q7k8EbLiy6Gq4BD14VJAyzndZ9eCEyIRqg==",
                    ConcurrencyStamp = "09588fed-5217-48d8-8297-597bdc02b6a8",
                    PhoneNumberConfirmed = true,
                    SecurityStamp = "2KAOINM2JZWTT2JUXK26JBRF7XLVI2R6",
                    TwoFactorEnabled = false,
                    UserName = "administrator",
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7222",
                    UserId = "5f72f83b-7436-4221-869c-1b69b2e23aae"
                }
             );



        }
    }
}
