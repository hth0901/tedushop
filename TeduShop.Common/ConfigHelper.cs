﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TeduShop.Common
{
    public class ConfigHelper
    {
        public static string GetByKey(string strKey)
        {
            return ConfigurationManager.AppSettings[strKey].ToString();
        }
    }
}
