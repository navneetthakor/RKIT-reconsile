﻿using System.Web;
using System.Web.Mvc;

namespace _7_devExtreme_demo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
