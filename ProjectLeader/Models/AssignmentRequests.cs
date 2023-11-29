using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.Models
{
    public class AssignmentRequests
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please your addressed to")]
        [Display(Name = "Addressed To")]
        [StringLength(50)]
        public Guid AddressedTo { get; set; }

        [Required(ErrorMessage = "Please your requested for")]
        [Display(Name = "Requested For")]
        [StringLength(50)]
        public Guid RequestedFor { get; set; }

        [Display(Name = "Id User-a")]
        public Guid CreatedBy { get; set; }

        [Required(ErrorMessage = "Please from project")]
        [Display(Name = "From Project")]
        [StringLength(50)]
        public Guid FromProject { get; set; }

        [Required(ErrorMessage = "Please to project")]
        [Display(Name = "To Project")]
        [StringLength(50)]
        public Guid ToProject { get; set; }

        [Required(ErrorMessage = "Please your start date")]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please your end date")]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }
        public int StatusId { get; set; }





        [ForeignKey("AddressedTo")]
        public Employee EmployeeAddressed { get; set; }

        [ForeignKey("RequestedFor")]
        public Employee EmployeeRequested { get; set; }

        [ForeignKey("CreatedBy")]
        public ApplicationUser EmployeeCreated { get; set; }

        [ForeignKey("FromProject")]
        public Project ProjectFrom { get; set; }

        [ForeignKey("ToProject")]
        public Project ProjectTo { get; set; }

        [ForeignKey("StatusId")]
        public Status Status { get; set; }
    }
}
