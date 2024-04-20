using InfrastructureGenerator.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureGenerator.BLL.Implementations
{
    public class TerraformScriptGenerator : ITerraformScriptGenerator
    {
        private string? _configParameter1;
        private string? _configParameter2;
        private string? _configParameter3;
        private string? _configParameter4;
        private string? _configParameter5;
        private string? _configParameter6;

        public void Configure(string configParameter1, string configParameter2, string configParameter3, string configParameter4, string configParameter5, string configParameter6)
        {
            _configParameter1 = configParameter1;
            _configParameter2 = configParameter2;
            _configParameter3 = configParameter3;
            _configParameter4 = configParameter4;
            _configParameter5 = configParameter5;
            _configParameter6 = configParameter6;



        }

        public string GenerateScript()
        {
            string script = $"resource \"azurerm_virtual_machine\" \"{_configParameter1}\" {{\n\tname = \"{_configParameter1}\"\n\tlocation = \"{_configParameter2}\"\n}}" +
            $"\n\nresource \"azurerm_virtual_network\" \"vnet\" {{\n name  = \"{_configParameter3}\"\n address_space       = [\"{_configParameter4}\"]\n location            = azurerm_resource_group.rg.{_configParameter5}\n resource_group_name = azurerm_resource_group.rg.{_configParameter6}\n}}";
           
            return script;
        }
    }
}
