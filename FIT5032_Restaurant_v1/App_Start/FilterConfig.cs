﻿using System.Web;
using System.Web.Mvc;

namespace FIT5032_Restaurant_v1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
