using ElectronicStore.Models;
using ElectronicStore.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ElectronicStore.Data
{
    public class Seed
    {

        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.ExecuteSqlRaw(@"
                    INSERT INTO Products (Name, Brand, Category, Price, Description, CreatedAt)
                    VALUES
                    ('Laptop LENOVO IdeaPad', 'Lenovo', 'Computers', 4500, 'Super laptop',  GETDATE()),
                    ('Smartwatch HUAWEI Watch GT ', 'Huawei', 'Accessorias', 3000, 'Super smartwatch',  GETDATE()),
                    ('Mouse LOGITECH M185', 'Logitech', 'Accessorias', 200, 'Super mouse',  GETDATE())
                ");
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "jankowalski@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "JanKowalski",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            City = "Krakow",
                            Street = "Pradnicka",
                            PostalCode = "30-321",
                            HouseNumber = 25
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "Admin1234!");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "olakot@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "OlaKot",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            City = "Krakow",
                            Street = "Czarnowiejska",
                            PostalCode = "38-656",
                            HouseNumber = 30
                        }
                    };
                    await userManager.CreateAsync(newAppUser, "User1234!");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
