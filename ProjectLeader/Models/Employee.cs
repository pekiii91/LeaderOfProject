using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectLeader.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please  your first name")]
        [Display(Name = "First name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please your first name")]
        [Display(Name = "Last name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please  your email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Please your Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public int GenderId { get; set; }

        [Required]
        [Display(Name = "Please your city")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Please your state")]
        public string State { get; set; }


        [ForeignKey("GenderId")]
        public Gender Gender { get; set; }

    }
}
