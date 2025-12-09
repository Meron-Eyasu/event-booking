using EventBooking.Data.Static;
using EventBooking.Models;
using Microsoft.AspNetCore.Identity;

namespace EventBooking.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Venue 
                if (!context.Venues.Any())
                {
                    context.Venues.AddRange(new List<Venue>()
                        {
                            new Venue()
                            {
                                Name = "Laphto Mall",
                                Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTplrxqp-LqAdIdTFSEtr7JdulpOMY96zaHIGarvQ5Kg&s",
                                Description = "This is a multi-purpose mall consisting of a grocery store, numerous places to buy clothes and toys, a liquor store, and a mobile phone store. This mall has several levels each with a number of small rooms selling goods. Lafto also consists of a large outdoor swimming pool."
                            },
                            new Venue()
                            {
                                Name = "Durant Arts Center",
                                Picture = "https://www.se.edu/wp-content/uploads/2019/04/VPAC1.jpg",
                                Description = "Home to offices, classrooms, and performance spaces for Southeastern’s Theatre program\r\nLocated on 1st Ave north of University Blvd. and south of Magnolia Ave"
                            },
                            new Venue()
                            {
                                Name = "Jingshan Garden Hotel",
                                Picture = "https://www.thebeijinger.com/sites/default/files/directory-images/385889/wei_xin_tu_pian_20221031123340.jpg",
                                Description = "Adjacent to the famous Jingshan Park, The Jingshan Garden Hotel is a Cultural Oasis of tranquility in the very heart of the vibrant city of Beijing."
                            },
                            new Venue()
                            {
                                Name = "Africa Center Hong Kong",
                                Picture = "https://media-cdn.tripadvisor.com/media/photo-s/02/1c/fe/dc/entrance-close-to-ghion.jpg",
                                Description = "It is a platform & creative hub that fosters value-creating interactions between African and non-African communities in Asia"
                            },
                            new Venue()
                            {
                                Name = "The Hub Hotel",
                                Picture = "https://dynamic-media-cdn.tripadvisor.com/media/Picture-o/17/fe/55/e1/the-hub-hotel-at-night.jpg?w=700&h=-1&s=1",
                                Description = "The Hub Hotel offers a free access rooftop fitness center, an indoor pool, free shuttle service, and free charging stations for electric cars."
                            }

                        });
                    context.SaveChanges();
                }

                //Events
                if (!context.Events.Any())
                {
                    context.Events.AddRange(new List<Event>()
                        {
                            new Event()
                            {
                                Name = "Ethiopian Art: Christian Narratives from the Kebra Nagast",
                                Description = "This exhibit displays religious and political artworks with the Kebra Nagast, Ethiopia’s sacred Christian text. Most of these works date from the 20th century, but the religious motifs are ancient.",
                                Price = 42.50,
                                ImageURL = "https://uwm.edu/specialevents/wp-content/uploads/sites/52/2020/02/Morgan-Poster-page-001-1536x2048.jpg",
                                StartDate = DateTime.Now.AddDays(-10),
                                EndDate = DateTime.Now.AddDays(10),
                                VenueId = 1,
                                Category = "Art Gallery"
                            },
                            new Event()
                            {
                                Name = "Eritrean and Ethiopian Cultural Celebration",
                                Description = "Eritrean and Ethiopian Cultural Celebration, the first ever in Beijing, that will be taking place at JinShang on Saturday, May 13. Behind the event are Martha Woldu, an artist from Eritrea and educator Sossena from Ethiopia.",
                                Price = 200,
                                ImageURL = "https://www.thebeijinger.com/sites/default/files/styles/800_width/public/wechat_image_20230504103045.jpg",
                                StartDate = DateTime.Now.AddDays(7),
                                EndDate = DateTime.Now.AddDays(10),
                                VenueId = 3,
                                Category = "Celebration"
                            },
                            new Event()
                            {
                                Name = "Made in Ethiopia Bazaar and Festival",
                                Description = "Made in Ethiopia is part of the Creative Neighborhood Grant Program which was funded by the city of Alexandia and National Endowment for Arts",
                                Price = 0.0,
                                ImageURL = "https://mefthe.com/wp-content/uploads/2022/10/423894.jpg",
                                StartDate = DateTime.Now.AddDays(-100),
                                EndDate = DateTime.Now.AddDays(-98),
                                VenueId = 2,
                                Category = "Bazaar and Festival"
                            },
                            new Event()
                            {
                                Name = "Comedy Night 3",
                                Description = "Life is better when you are laughing and for Shifta Foods, an Afro Vegan and Caribbean restaurant, which organizes unique events, has decided to grace the residents of Addis Ababa with a comedy night.",
                                Price = 17,
                                ImageURL = "https://www.thereporterethiopia.com/wp-content/uploads/2022/04/Stuck-in-the-past.jpg",
                                StartDate = DateTime.Now.AddDays(-10),
                                EndDate = DateTime.Now.AddDays(10),
                                VenueId = 5,
                                Category = "Comedy"
                            },
                            new Event()
                            {
                                Name = "Ethiopian Dinner and Coffee Meetup",
                                Description = "It is a shared experience that includes everyone around the table and creates a communal feeling for all those involved. In addition to its flavourful dishes, stews and spices.",
                                Price = 30.0,
                                ImageURL = "https://www.africacenterhk.com/wp-content/uploads/3-29-1536x864.png",
                                StartDate = DateTime.Now.AddDays(-10),
                                EndDate = DateTime.Now.AddDays(-9),
                                VenueId = 4,
                                Category = "Dinner, Drinks, and Food"
                            },

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
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@eventbooking.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "Admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@12345?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@eventbooking.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "User",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@12345?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
