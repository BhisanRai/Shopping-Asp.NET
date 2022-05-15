using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Models
{
    public class Matrial
    {
        public int MatrialID { get; set; }

        public string Name { get; set; }

        public string Part { get; set; }


        //Navigation
        public ICollection<MaterialItem> Item { get; set; }

        public Matrial()
        {
            Item = new HashSet<MaterialItem>();
        }
    }
}
