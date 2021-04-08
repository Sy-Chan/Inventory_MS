using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_MS.Models;

namespace Inventory_MS.Models
{
    public class ViewModel
    {
        public Type Types{ get; set; }
        public Inventory Inventory { get; set; }
        public RepairRecord Repair { get; set; }
    }
}
