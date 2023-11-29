using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.Models
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Please select your code")]
        public string Code { get; set; }

        [Required]
        [Display(Name = "Please your description")]
        public string Description { get; set; }
           
    }
}
