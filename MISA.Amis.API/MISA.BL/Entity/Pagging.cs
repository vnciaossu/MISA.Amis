using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL.Entity
{
    public class Pagging
    {
        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 10;
        public string fillter { get; set; } = null;

    }
}
