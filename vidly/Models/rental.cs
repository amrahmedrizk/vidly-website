using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class rental
    {
        public int id { get; set; }
        public customer customer { get; set; }
        public movie movie { get; set; }
        public DateTime rentdate { get; set; }
        public DateTime? returndate { get; set; }
    }
}