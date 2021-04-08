using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Inventory_MS.Models
{
    public class User
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }

    }
}
