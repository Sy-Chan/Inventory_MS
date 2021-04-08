using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_MS.Controllers
{
    public class IMS : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
