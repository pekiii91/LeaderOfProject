using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.Models
{
    public class CurrentAssignment
    {
     
        [Required(ErrorMessage = "Please your start date")]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please your end date")]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        public Guid ProjectId { get; set; }

        public Guid EmployeeId { get; set; }






        [ForeignKey("ProjectId")]
        public Project Project { get; set; }  

        
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
  
    }
}
