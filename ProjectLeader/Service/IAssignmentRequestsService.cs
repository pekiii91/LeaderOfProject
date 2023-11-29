using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectLeader.Models;
using ProjectLeader.Models.CurrentHelperModels;

namespace ProjectLeader.Service
{
    public interface IAssignmentRequestsService
    {
        AssignmentHelperModel GetAssignment(Guid id);
        IResponse<List<AssignmentRequestsIndex>> GetAssignmentRequests(string id);
        IResponse<List<RequestedFromMeIndex>> GetRequestsFromMe();
        IResponse<NoValue> AddAssignmentRequests(AssignmentHelperModel model, string userId);
        AssignmentHelperModel GetAssignmentModal();
        IResponse<NoValue> UpdateStatusApproveRequest(AssignmentHelperModel model);
        IResponse<NoValue> DeclineStatusRequest(AssignmentHelperModel model);
    }
}
