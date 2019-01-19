using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.dtos
{
    public class moviedto
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }

        [Required]
        public DateTime releasedate { get; set; }

        [Required]
        public DateTime dateadded { get; set; }

        [Required]
        [Range(1, 20)]
        public int numberinstock { get; set; }

        public int genraid { get; set; }
        public genradto genra { get; set; }
    }
}