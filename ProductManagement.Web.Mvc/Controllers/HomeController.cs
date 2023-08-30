﻿using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using ProductManagement.Controllers;

namespace ProductManagement.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : ProductManagementControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
