using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_MS.Models
{
    public class Type
    {
        public int ID { get; set; }
        public string InType { get; set; }
        public Code Code { get; set; }
        public string ShortName { get; set; }
    }
    public enum Code
    {
        [Display(Name = "CA")] CA = 1,
        [Display(Name = "CT")] CT = 2,
        [Display(Name = "FU")] FU = 3,
        [Display(Name = "MA")] MA = 4,
        [Display(Name = "ST")] ST = 5,
        [Display(Name = "TC")] TC = 6
    }
}
