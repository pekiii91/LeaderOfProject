using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.Models
{
    public class Project
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please your name")]
        [Display(Name = "Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please your start date")]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please  your end date")]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Please  your path")]
        [Display(Name = "Path")]
        [StringLength(50)]
        public string Path { get; set; }

        [Required(ErrorMessage = "Please select project lead")]
        [Display(Name = "Project lead")]
        [StringLength(50)]
        public Guid ProjectLeadId { get; set; }

        public int StatusId { get; set; }





        [ForeignKey("ProjectLeadId")]
        public Employee ProjectLead { get; set; }

        [ForeignKey("StatusId")]
        public Status Status { get; set; }



    }
}
