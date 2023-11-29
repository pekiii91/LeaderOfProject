using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.Models.CurrentHelperModels
{
    public class CurrentAssignnmentHelperModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Project { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
