using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.dtos
{
    public class customerdto
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public bool issubscribedtonewsletter { get; set; }
        public int membershiptypeid { get; set; }
        public membershiptypesdto membershiptype { get; set; }
        //[min18yearsifamember]
        public DateTime? birthdate { get; set; }
    }
}