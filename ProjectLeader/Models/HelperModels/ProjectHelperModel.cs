using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.Models.HelperModels
{
    public class ProjectHelperModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } //Ime projekta
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Path { get; set; }
        public Guid ProjectLeadId { get; set; } //ref na Employee
        public int StatusId { get; set; }

        public List<SelectListItem> EmployeesList { get; set; }
        public List<SelectListItem> StatusList { get; set; }
    }
}
