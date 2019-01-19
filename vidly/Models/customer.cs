using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class customer
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public bool issubscribedtonewsletter { get; set; }
        public membershiptype membershiptype { get; set; }
        public int membershiptypeid { get; set; }
        [min18yearsifamember]
        public DateTime? birthdate { get; set; }
    }
}