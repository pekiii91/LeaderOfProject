using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.Models.CurrentHelperModels
{
    public class RequestedFromMeIndex
    {
        public Guid Id { get; set; }
        public string RequestedFrom { get; set; }
        public string RequestedFor { get; set; }
        public string FromProject { get; set; }
        public string ToProject { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
    }
}
