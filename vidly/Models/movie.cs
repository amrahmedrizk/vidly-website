using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class movie
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }

        [Required]
        [Display(Name ="release date")]
        public DateTime releasedate { get; set; }

        [Required]
        public DateTime dateadded { get; set; }

        [Required]
        [Range(1,20)]
        [Display(Name = "number in stock")]
        public int numberinstock { get; set; }

        public int numberavailable { get; set; }

        public genra genra { get; set; }
        public int genraid { get; set; }
    }
}