using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_labs.Controllers
{
    public class ExchangesController : Controller
    {
        public IActionResult Display()
        {
            return View();
        }
    }
}
