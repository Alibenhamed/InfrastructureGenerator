using InfrastructureGenerator.BLL.Implementations;
using InfrastructureGenerator.BLL.Interfaces;

namespace InfrastructureGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<ITerraformScriptGenerator, TerraformScriptGenerator>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();


            {
                ITerraformScriptGenerator scriptGenerator = new TerraformScriptGenerator();

                Console.WriteLine("Enter parameter 1:");
                string param1 = Console.ReadLine();

                Console.WriteLine("Enter parameter 2:");
                string param2 = Console.ReadLine();

                Console.WriteLine("Enter parameter 3:");
                string param3 = Console.ReadLine();

                Console.WriteLine("Enter parameter 4:");
                string param4 = Console.ReadLine();

                Console.WriteLine("Enter parameter 5:");
                string param5 = Console.ReadLine();

                Console.WriteLine("Enter parameter 6:");
                string param6 = Console.ReadLine();

                scriptGenerator.Configure(param1, param2, param3, param4, param5, param6);

                string terraformScript = scriptGenerator.GenerateScript();

                Console.WriteLine("Generated Terraform Script:");
                Console.WriteLine(terraformScript);
            }
        }
    }
}

