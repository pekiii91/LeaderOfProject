using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.Models.HelperModels
{
    public class ProjectManagement
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Path { get; set; }
        public string ProjectLead { get; set; }
        public string Status { get; set; } //ovde sam ispravio u StatusId

    }
}
