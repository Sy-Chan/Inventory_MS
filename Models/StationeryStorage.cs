using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_MS.Models
{
    public class StationeryStorage
    {
        public int ID { get; set; }
        public string type { get; set; }
        public string brand { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateIn { get; set; }

        public int amount { get; set; }

        public string Remarks { get; set; }
    }
    
}
