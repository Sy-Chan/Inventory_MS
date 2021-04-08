using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Inventory_MS.Models;

namespace Inventory_MS.Models
{
    public class Inventory
    {
        public int ID { get; set; }
        public Code Type { get; set; }
        public string Items { get; set; }
        public string ObjectID { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateIn { get; set; }

        public string Status { get; set; }
        public string Departments { get; set; }
        public string Remarks { get; set; }
    }

    
}
