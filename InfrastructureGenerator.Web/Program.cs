//using FluentAssertions.Common;
//using InfrastructureGenerator.BLL.Implementations;
//using InfrastructureGenerator.BLL.Interfaces;

//namespace InfrastructureGenerator.Web
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            builder.Services.AddScoped<ITerraformScriptGenerator, TerraformScriptGenerator>();

//                        builder.Services.AddScoped<ITerraformScriptGenerator, TerraformScriptGenerator>();



//            // Add services to the container.
//            builder.Services.AddRazorPages();

//            var app = builder.Build();

//            // Configure the HTTP request pipeline.
//            if (!app.Environment.IsDevelopment())
//            {
//                app.UseExceptionHandler("/Error");
//                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//                app.UseHsts();
//            }

//            app.UseHttpsRedirection();
//            app.UseStaticFiles();

//            app.UseRouting();

//            app.UseAuthorization();

//            app.MapRazorPages();

//            app.Run();

//            app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Home}/{action=Index}/{id?}");
//});
//        }

//    }

//}
