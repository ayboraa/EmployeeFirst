using Npgsql;
using EmployeeFirst.Database.Repositories;

namespace EmployeeFirst
{
    public class Program
	{
		public static void Main(string[] args)
		{


            var builder = WebApplication.CreateBuilder(args);

			

			DBEmployeeRepository.Initialize();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

			builder.Services.AddMvc(options => {

				options.MaxModelValidationErrors = 100;
				options.EnableEndpointRouting = false;
			
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.UseMvc(routes => {

				routes.MapRoute(
				name: "default",
				template: "{controller=Home}/{action=Index}/{id?}");

			});


			app.Run();
		}
	}
}