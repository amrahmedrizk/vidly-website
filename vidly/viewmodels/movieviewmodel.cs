using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.viewmodels
{
    public class movieviewmodel
    {
        public movie movies { get; set; }
        public List<genra> genra { get; set; }
    }
}