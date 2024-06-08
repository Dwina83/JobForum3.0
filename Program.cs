using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using JobForum3._0.Data;
namespace JobForum3._0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("JobForum3_0ContextConnection") ?? throw new InvalidOperationException("Connection string 'JobForum3_0ContextConnection' not found.");

            builder.Services.AddDbContext<JobForum3_0Context>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<Areas.Identity.Data.JobForum3_0User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<JobForum3_0Context>();

            builder.Services.AddAuthorization(option => option.AddPolicy("Admin", policy => policy.RequireRole("Admin")));

            //Add Cookies
            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Add services to the container.
            builder.Services.AddRazorPages(option => option.Conventions.AuthorizeFolder("/RoleAdmin", "Admin"));

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

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
