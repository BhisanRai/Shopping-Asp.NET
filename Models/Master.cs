using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Models
{
    public class Master
    {
        public ICollection<Matrial> Matrial { get; set; }
        public ICollection<MaterialItem> MaterialItem { get; set; }

        public Master()
        {
            Matrial = new HashSet<Matrial>();
            MaterialItem = new HashSet<MaterialItem>();
        }
    }
}
