﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingConfigFile
{
    class Program
    {
        static void Main(string[] args)
        {
            ToolsSettingsSection toolsSection = (ToolsSettingsSection)ConfigurationManager.GetSection("myToolsSettingSection");

            // get settings
            var sett = toolsSection.Settings.FirstOrDefault(x => x.Name == "appVersion");

            // get xml formats
            var xmlFormats = toolsSection.XmlFormats.FirstOrDefault(y => y.Value == "advance");
            
            // get countries
            var countries = toolsSection.Countries;

            // get database objects
            var dbobj = toolsSection.DatabaseObjects.FirstOrDefault(x => x.Name == "userTable1");
        }
    }
}
