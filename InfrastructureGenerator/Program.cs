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

            app.UseEndpoints(endpoints =>
            {
              endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
            });

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


                Console.WriteLine("Enter parameter 7:");
                string param7 = Console.ReadLine();

                Console.WriteLine("Enter parameter 8:");
                string param8 = Console.ReadLine();

                Console.WriteLine("Enter parameter 9:");
                string param9 = Console.ReadLine();

                Console.WriteLine("Enter parameter 10:");
                string param10 = Console.ReadLine();

                Console.WriteLine("Enter parameter 11:");
                string param11 = Console.ReadLine();

                Console.WriteLine("Enter parameter 12:");
                string param12 = Console.ReadLine();

                scriptGenerator.Configure(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12);

                string terraformScript = scriptGenerator.GenerateScript();

                Console.WriteLine("Generated Terraform Script:");
                Console.WriteLine(terraformScript);
            }
        }
    }
}

