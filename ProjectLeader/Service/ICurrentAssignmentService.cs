using ProjectLeader.Models;
using ProjectLeader.Models.CurrentHelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.Service
{
    public interface ICurrentAssignmentService
    {
        IResponse<List<CurrentAssignnmentHelperModel>> GetCurrentAssignment();

        //IResponse<List<RequestedFromMeIndex>> GetCurrentAssignment();
    }
}
