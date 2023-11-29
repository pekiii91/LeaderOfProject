using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.Models.CurrentHelperModels
{
    public class AssignmentHelperModel
    {
        public Guid Id { get; set; }
        public Guid EmployeeAddressed { get; set; }
        public Guid EmployeeRequested { get; set; }
        public Guid EmployeeCreated { get; set; }
        public Guid ProjectFrom { get; set; }
        public Guid ProjectTo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StatusId { get; set; }

        public List<SelectListItem> EmployeesList { get; set; }
        public List<SelectListItem> ProjectsList { get; set; }
        public List<SelectListItem> StatusList { get; set; }

    }
}
