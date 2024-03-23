using Newtonsoft.Json;
using Repository.Interface;
using Repository;

namespace Test_PE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<IAccountRepository, AccountRepository>();
            builder.Services.AddTransient<ISilverJewelryRepository, SilverJewelryRepository>();
            builder.Services.AddTransient<IHelper, Helper>();
            builder.Services.AddTransient<ICategoryRepsitory, CategoryRepsitory>();


            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddMvc()
                    .AddNewtonsoftJson(
                            options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; }
            );
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}