using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class membershiptype
    {
        public int id { get; set; }
        public string name { get; set; }
        public int signupfee { get; set; }
        public int durationmonthes { get; set; }
        public int discountrate { get; set; }
    }
}