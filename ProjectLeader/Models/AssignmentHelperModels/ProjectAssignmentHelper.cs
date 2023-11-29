using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.Models.AssignmentHelperModels
{
    public class ProjectAssignmentHelper
    {
        public Guid Id { get; set; }
        public Guid  FirstName { get; set; }
        public Guid LastName { get; set; }
        public Guid Project { get; set; }
    }
}
