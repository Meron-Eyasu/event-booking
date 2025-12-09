using EventBooking.Models;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;




namespace EventBooking.Data
{
    public class AppDbContext: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
   
        public DbSet<Event> Events { get; set; }
        public DbSet<Venue> Venues { get; set; }


        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}



//var builder = WebApplication.CreateBuilder(args);

////DbContext configuration
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
//           builder.Configuration.GetConnectionString("DefaultConnectionString")));
//// Add services to the container.
//builder.Services.AddControllersWithViews();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();
//app.UseSession();

////Authentication & Authorization
//app.UseAuthentication();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();
////Seed database
////AppDbInitializer.Seed(app);
////AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();
///


///////////////////////// program.cs 
//namespace EventBooking
//{
//    public class Program
//    {
//        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();
//                });
//    }
//}


//////////////////// startup.cs
//using EventBooking.Data;
//using EventBooking.Data.Cart;
//using EventBooking.Data.Services;
//using EventBooking.Models;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Builder;
//namespace EventBooking
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {

//            //DbContext configuration
//            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

//            //Services configuration
//            services.AddScoped<IVenuesService, VenuesService>();
//            services.AddScoped<IEventsService, EventsService>();
//            services.AddScoped<IOrdersService, OrdersService>();

//            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//            services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

//            //Authentication and authorization
//            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
//            services.AddMemoryCache();
//            services.AddSession();
//            services.AddAuthentication(options =>
//            {
//                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//            });

//            services.AddControllersWithViews();
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }
//            else
//            {
//                app.UseExceptionHandler("/Home/Error");
//                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//                app.UseHsts();
//            }
//            app.UseHttpsRedirection();
//            app.UseStaticFiles();

//            app.UseRouting();
//            app.UseSession();

//            //Authentication & Authorization
//            app.UseAuthentication();
//            app.UseAuthorization();

//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllerRoute(
//                    name: "default",
//                    pattern: "{controller=Events}/{action=Index}/{id?}");
//            });

//            //Seed database
//            AppDbInitializer.Seed(app);
//            AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();
//        }
//    }
//}

