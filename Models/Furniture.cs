using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_MS.Models
{
    public class Furniture
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateIn { get; set; }

        public string status { get; set; }
        public string departments { get; set; }
        public string Remarks { get; set; }

    }
}
