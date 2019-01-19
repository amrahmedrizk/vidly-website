using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.viewmodels
{
    public class customerviewmodel
    {
        public customer customer { get; set; }
        public List<membershiptype> membershiptype { get; set; }
    }
}