using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.Models.CurrentHelperModels
{
    public class AssignmentRequestsIndex
    {
        public Guid Id { get; set; }
        public string AddressedTo { get; set; }
        public string RequestedFor { get; set; }
        public Guid CreatedBy {get;set;}
       // public string CreatedBy { get; set; }
        public string FromProject { get; set; }
        public string ToProject { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
    }
}
