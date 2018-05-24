﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLGVT.Extensions;

namespace QLGVT.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {

        public IActionResult Index()
        {
            var email = User.GetSpecificClaim("Email");
            return View();
        }
    }
}
