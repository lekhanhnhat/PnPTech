﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cilent.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        public ActionResult AddressAndPayment()
        {
            return View();
        }
        public ActionResult Complete()
        {
            return View();
        }
    }
}