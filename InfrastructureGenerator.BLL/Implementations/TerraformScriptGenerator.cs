using InfrastructureGenerator.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        private string? _configParameter7;
        private string? _configParameter8;
        private string? _configParameter9;
        private string? _configParameter10;
        private string? _configParameter11;
        private string? _configParameter12;




        public void Configure(string configParameter1, string configParameter2, string configParameter3, string configParameter4, string configParameter5, string configParameter6, string configParameter7, string configParameter8, string configParameter9, string configParameter10, string configParameter11, string configParameter12)
        {
            _configParameter1 = configParameter1;
            _configParameter2 = configParameter2;
            _configParameter3 = configParameter3;
            _configParameter4 = configParameter4;
            _configParameter5 = configParameter5;
            _configParameter6 = configParameter6;
            _configParameter7 = configParameter7;
            _configParameter8 = configParameter8;
            _configParameter9 = configParameter9;
            _configParameter10 = configParameter10;
            _configParameter11 = configParameter11;
            _configParameter12 = configParameter12;

        }

        public string GenerateScript()
        {

            string script = $@"


 resource ""azurerm_resource_group"" ""{_configParameter1}"" {{
  name = ""{_configParameter1}""
  location = ""{_configParameter2}""
 }}

 resource ""azurerm_app_service_plan"" ""plan"" {{
  resource_group_name = azurerm_resource_group.rg.{_configParameter1}
  name = ""{_configParameter3}""
  location = azurerm_resource_group.rg.{_configParameter2}
  kind = ""{_configParameter4}""
  reserved = false
  sku = ""B1""

  hosting_mode = ""Linux""
  reserved      = false
  query_string_cache_size_bytes = 0


  depends_on = [
    azurerm_resource_group.rg,
  ]
    }}


 resource ""azurerm_container_registry"" ""acr"" {{
  resource_group_name = azurerm_resource_group.rg.{_configParameter1}
  name = ""{_configParameter5}""
  location = azurerm_resource_group.rg.{_configParameter2}
  sku = ""Standard""
  admin_enabled = true

  depends_on = [
    azurerm_resource_group.rg,
  ]
}}

resource ""azurerm_container_image"" ""image"" {{
  resource_group_name = azurerm_resource_group.rg.{_configParameter1}
  name                = ""{_configParameter6}""
  registry           = azurerm_container_registry.acr.login_server
  tag                = ""{_configParameter7}""
  source_image       = ""{_configParameter8}""

  depends_on = [
    azurerm_container_registry.acr,
  ]
}}

resource ""azurerm_app_service"" ""app"" {{
  resource_group_name = azurerm_resource_group.rg.{_configParameter1}
  name                = ""{_configParameter9}""
  location            = azurerm_resource_group.rg.{_configParameter2}
  app_service_plan_id = azurerm_app_service_plan.plan.id

  site_config {{
    linux_fx_version = ""DOCKER|debian-10""
    linux_container_settings {{
      docker_file_path = ""{_configParameter10}""
      network_switch = ""{_configParameter11}""
    }}
    application_settings {{
      WEBSITE_NODE_EXTRA_PORTS = ""{_configParameter12}""
    }}
  }}

  depends_on = [
    azurerm_app_service_plan.plan,
    azurerm_container_image.image,
  ]
}}
";

            return script;
            }
        }
    }
