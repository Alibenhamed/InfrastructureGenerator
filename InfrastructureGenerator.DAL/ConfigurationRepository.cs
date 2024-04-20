using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InfrastructureGenerator.DAL
{
    public class ConfigurationRepository
    {
        public string[] GetConfigurationFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllLines(filePath);
            }
            else
            {
                return new string[0];
            }
        }
    }
}