using InfrastructureGenerator.BLL.Implementations;
using InfrastructureGenerator.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InfrastructureGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITerraformScriptGenerator _TerraformScriptGenerator;

        public HomeController(ITerraformScriptGenerator TerraformScriptGenerator)
        {
            _TerraformScriptGenerator = TerraformScriptGenerator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View( new TerraformScriptViewModel());
        }

        [HttpPost]
 
        public IActionResult Index(TerraformScriptViewModel model)
        {
            if (ModelState.IsValid)
            {
                _TerraformScriptGenerator.Configure(model.Param1, model.Param2, model.Param3, model.Param4, model.Param5, model.Param6);
                model.TerraformScript = _TerraformScriptGenerator.GenerateScript();
            }
            return View(model);
        }

    }
}