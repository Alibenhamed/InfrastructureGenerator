using InfrastructureGenerator.BLL.Implementations;
using InfrastructureGenerator.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.IO;

namespace InfrastructureGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITerraformScriptGenerator _terraformScriptGenerator;

        public HomeController(ITerraformScriptGenerator terraformScriptGenerator)
        {
            _terraformScriptGenerator = terraformScriptGenerator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new TerraformScriptViewModel());
        }

        [HttpPost]


        public IActionResult Index(TerraformScriptViewModel model)
        {
            if (ModelState.IsValid)
            {
                _terraformScriptGenerator.Configure(model.Param1, model.Param2, model.Param3, model.Param4, model.Param5, model.Param6, model.Param7, model.Param8, model.Param9, model.Param10, model.Param11, model.Param12);
                model.TerraformScript = _terraformScriptGenerator.GenerateScript();

                // Vérifier si le fichier main.tf existe, sinon le créer
                string mainTfPath = Path.Combine(Environment.CurrentDirectory, "main.tf");
                CreateMainTfFile(mainTfPath, "terraform { }");


                // Exécuter la commande "terraform init" pour initialiser le répertoire
                ExecuteTerraformCommand("init", Environment.CurrentDirectory);

                // Valider le script Terraform
                string validateError = ValidateOrPlanTerraformScript(model.TerraformScript, false);

                if (validateError == null)
                {
                    // Valider la génération du plan Terraform
                    string planError = ValidateOrPlanTerraformScript(model.TerraformScript, true);

                    if (planError == null)
                    {
                        // Afficher le script Terraform
                        ViewBag.Script = model.TerraformScript;
                        ViewBag.ValidationMessage = "Le script Terraform est valide.";
                    }
                    else
                    {
                        // Afficher les erreurs de la commande plan
                        ViewBag.ValidationMessage = "La génération du plan Terraform a échoué : " + planError;
                    }
                }
                else
                {
                    // Afficher les erreurs de la commande validate
                    ViewBag.ValidationMessage = "La validation du script Terraform a échoué : " + validateError;
                }
            }
            return View(model);
        }

        private void CreateMainTfFile(string filePath, string content)
        {
            if (!System.IO.File.Exists(filePath))
            {
                // Créer le fichier main.tf avec un contenu par défaut
                System.IO.File.WriteAllText(filePath, content);
            }
        }


        private void ExecuteTerraformCommand(string command, string workingDirectory)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "terraform",
                Arguments = command,
                WorkingDirectory = workingDirectory,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = startInfo })
            {
                process.Start();

                // Lire la sortie standard et la sortie d'erreur
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                // Afficher la sortie et l'erreur
                Console.WriteLine(output);
                Console.WriteLine(error);
            }
        }

        private string ValidateOrPlanTerraformScript(string script, bool isPlan)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "terraform",
                Arguments = isPlan ? "plan -" : "validate -",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = startInfo })
            {
                process.Start();

                // Écrire le script dans l'entrée standard du processus
                process.StandardInput.WriteLine(script);
                process.StandardInput.Close();

                // Lire la sortie standard et la sortie d'erreur
                string output = process.StandardOutput.ReadToEnd();

                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                // Vérifier si le processus s'est terminé avec succès
                if (process.ExitCode == 0)
                {
                    // Le script est syntaxiquement correct ou le plan a été généré avec succès
                    Console.WriteLine(output);
                    return script;
                }
                else
                {
                    // Le script contient des erreurs de syntaxe ou le plan a échoué
                    Console.WriteLine(error);
                    return error;
                }

            }
        }
    }     
}
