﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureGenerator.BLL.Interfaces
{
    public interface ITerraformScriptGenerator
    {
        void Configure(string configParameter1, string configParameter2, string configParameter3 , string configParameter4, string configParameter5, string configParameter6, string configParameter7, string configParameter8, string configParameter9, string configParameter10, string configParameter11, string configParameter12);

        string GenerateScript();


    }
}