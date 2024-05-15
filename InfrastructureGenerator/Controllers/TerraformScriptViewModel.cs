using System.ComponentModel.DataAnnotations;
namespace InfrastructureGenerator.Controllers

{
    public class TerraformScriptViewModel
    {

        [Required(ErrorMessage = "Parameter 1 is required")]
        public  string Param1 { get; set; } = string.Empty;

        [Required(ErrorMessage = "Parameter 2 is required")]
        public  string Param2 { get; set; }= string.Empty;

        [Required(ErrorMessage = "Parameter 3 is required")]
        public string Param3 { get; set; } = string.Empty;

        [Required(ErrorMessage = "Parameter 4 is required")]
        public string Param4 { get; set; } = string.Empty;

        [Required(ErrorMessage = "Parameter 5 is required")]
        public string Param5 { get; set; } = string.Empty;

        [Required(ErrorMessage = "Parameter 6 is required")]
        public string Param6 { get; set; } = string.Empty;

        [Required(ErrorMessage = "Parameter 7 is required")]
        public string Param7 { get; set; } = string.Empty;

        [Required(ErrorMessage = "Parameter 8 is required")]
        public string Param8 { get; set; } = string.Empty;

        [Required(ErrorMessage = "Parameter 9 is required")]
        public string Param9 { get; set; } = string.Empty;

        [Required(ErrorMessage = "Parameter 10 is required")]
        public string Param10 { get; set; } = string.Empty;

        [Required(ErrorMessage = "Parameter 11 is required")]
        public string Param11 { get; set; } = string.Empty;

        [Required(ErrorMessage = "Parameter 12 is required")]
        public string Param12 { get; set; } = string.Empty;

        public string TerraformScript { get; set; }= string.Empty;

        public TerraformScriptViewModel() { 
        
            Param1 = string.Empty;
            Param2 = string.Empty;
            Param3 = string.Empty;
            Param4 = string.Empty;
            Param5 = string.Empty;
            Param6 = string.Empty;
            Param7 = string.Empty;
            Param8 = string.Empty;
            Param9 = string.Empty;
            Param10 = string.Empty;
            Param11 = string.Empty;
            Param12 = string.Empty;
            TerraformScript = string.Empty;

        }
    
    }
}