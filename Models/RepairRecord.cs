using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_MS.Models
{
    public class RepairRecord
    {
        public int ID { get; set; }
        public string ObjectID { get; set; }
        public string Supplier { get; set; }
        public float Payment { get; set; }
        public string Remarks { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateSend { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateBack { get; set; }


    }
}
