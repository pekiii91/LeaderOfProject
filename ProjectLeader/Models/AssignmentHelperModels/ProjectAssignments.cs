using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.Models.AssignmentHelperModels
{
    public class ProjectAssignments
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } //ref Employee
        public string LastName { get; set; } //ref Employee
        public string Project { get; set; } //ref Projecta to je (Name) Projecta

    }
}
