using Microsoft.AspNetCore.Identity;
using System.Net;
using TicketBus.Models;

namespace TicketBus.Data
{
    public class Seeddata
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                //buses
                if (!context.Buses.Any())
                {
                    context.Buses.AddRange(new List<Buses>()
                    {
                        new Buses()
                        {
                            image = "https://shac.vn/wp-content/uploads/2019/04/4-xe-buyt-thaco-city-40-cho.jpg",
                            bus_number = "A1",
                            bus_name = "THACO CITY"
                        },
                        new Buses()
                        {
                            image = "https://shac.vn/wp-content/uploads/2019/04/5-xe-buyt-thaco-county-25-cho.jpg",
                            bus_number = "A2",
                            bus_name = "THACO COUNTY LONG BODY"
                        },
                        new Buses()
                        {
                            image = "https://shac.vn/wp-content/uploads/2019/04/6-xe-buyt-thaco-mobihome-41-cho.jpg",
                            bus_number = "A3",
                            bus_name = "THACO AERO EXPRESS"
                        }

                    });
                    context.SaveChanges();
                }


                //Routes
                if (!context.Routes.Any())
                {
                    context.Routes.AddRange(new List<Routes>
                    {
                        new Routes()
                        {

                            start_point = "TP. Hồ Chí Minh",
                            end_point = "Bảo Lộc",
                            distance = 9,//donvi km
							description = "35 minute",
                        },
                        new Routes()
                        {

                            start_point = "TP. Hồ Chí Minh",
                            end_point = "An giang",
                            distance = 15,//donvi km
							description = "50 minute",

                        },
                        new Routes()
                        {

                            start_point = "Bạc Liêu",
                            end_point = "TP. Hồ Chí Minh",
                            distance = 38,//donvi km
							description = "100 minute",

                        },
                        new Routes()
                        {
                            start_point = "Quy Nhơn",
                            end_point = "TP. Hồ Chí Minh",
                            distance = 38,//donvi km
							description = "100 minute",

                        },
                        new Routes()
                        {
                            start_point = "Biên Hòa",
                            end_point = "TP. Hồ Chí Minh",
                            distance = 38,//donvi km
							description = "100 minute",

                        }
                    });
                    context.SaveChanges();
                }
                if (!context.BusRoutes.Any())
                {
                    context.BusRoutes.AddRange(new List<BusRoute>
                    {
                        new BusRoute()
                        {
                            bus_id = 1,
                            route_id = 1,
                            start_time = new TimeSpan(5, 0, 0),
                            end_time = new TimeSpan(8, 0, 0),
                            StartDate = "2023-08-12",
                            Price = 150000,
                            SeatsAvailable = 40
                        },
                        new BusRoute()
                        {
                            bus_id = 2,
                            route_id = 2,
                            start_time = new TimeSpan(5, 0, 0),
                            end_time = new TimeSpan(8, 0, 0),
                            StartDate = "2023-08-13",
                            Price = 250000,
                            SeatsAvailable = 25
                        },
                        new BusRoute()
                        {
                            bus_id = 3,
                            route_id = 3,
                            start_time = new TimeSpan(5, 0, 0),
                            end_time = new TimeSpan(17, 0, 0),
                            StartDate = "2023-08-14",
                            Price = 280000,
                            SeatsAvailable = 41
                        },

                        new BusRoute()
                        {
                            bus_id = 3,
                            route_id = 1,
                            start_time = new TimeSpan(5, 0, 0),
                            end_time = new TimeSpan(17, 0, 0),
                            StartDate = "2023-08-15",
                            Price = 250000,
                            SeatsAvailable = 25
                        },
                         new BusRoute()
                        {
                            bus_id = 3,
                            route_id = 4,
                            start_time = new TimeSpan(5, 0, 0),
                            end_time = new TimeSpan(17, 0, 0),
                            StartDate = "2023-08-16",
                            Price = 250000,
                            SeatsAvailable = 25
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.Employee))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Employee));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                //admin
                string adminUserEmail = "admin@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        FullName = "Admin Manager",
                        Role = "admin",
                        UserName = "Admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        PhoneNumber = "0909090909",
                        PhoneNumberConfirmed = true,
                    };
                    await userManager.CreateAsync(newAdminUser, "Abc@123@");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }
                //employee

                string appEmployeeEmail = "employee@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appEmployeeEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        FullName = "employeeTest",
                        Role = "employee",
                        UserName = "employee",
                        Email = appEmployeeEmail,
                        EmailConfirmed = true,
                        PhoneNumber = "0909090909",
                        PhoneNumberConfirmed = true,
                    };
                    await userManager.CreateAsync(newAppUser, "Abc@123@");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.Employee);
                }
                //user
                string appUserEmail = "user@gmail.com";

                var appUser2 = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser2 == null)
                {
                    var newAppUser = new AppUser()
                    {
                        FullName = "user",
                        Role = "user",
                        UserName = "user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        PhoneNumber = "0909090909",
                        PhoneNumberConfirmed = true,
                    };
                    await userManager.CreateAsync(newAppUser, "Abc@123@");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
