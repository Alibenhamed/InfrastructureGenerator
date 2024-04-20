using InfrastructureGenerator.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InfrastructureGenerator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITerraformScriptGenerator TerraformScriptGenerator;

        public HomeController(ITerraformScriptGenerator scriptGenerator)
        {
            TerraformScriptGenerator = scriptGenerator;
        }

        public IActionResult Index()
        {
            string terraformScript = TerraformScriptGenerator.GenerateScript();

            ViewBag.TerraformScript = terraformScript;

            return View();
        }
    }
}
