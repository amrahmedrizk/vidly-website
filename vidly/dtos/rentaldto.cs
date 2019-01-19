using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vidly.dtos
{
    public class rentaldto
    {
        public int customerid { get; set; }
        public List<int> movieids { get; set; }
        //public DateTime? returndate { get; set; }
    }
}