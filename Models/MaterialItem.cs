using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Models
{
    public class MaterialItem
    {
        public int MaterialItemID { get; set; }

        public string ItemName { get; set; }

        public string ItemType { get; set; }

        public bool State { get; set; }


        //Navigation
        public int MatrialID { get; set; }
        public Matrial Matrial { get; set; }
    }
}
