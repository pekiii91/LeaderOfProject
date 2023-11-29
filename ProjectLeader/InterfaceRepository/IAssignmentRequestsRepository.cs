using ProjectLeader.Models;
using ProjectLeader.Models.CurrentHelperModels;
using ProjectLeader.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.InterfaceRepository
{
    public interface IAssignmentRequestsRepository :IGenericRepository<AssignmentRequests>
    {
        IEnumerable<AssignmentRequests> AllAssignmentRequests { get; }
        AssignmentRequests GetAssignmentRequestsById(Guid id);
        List<AssignmentRequests> GetAssignmentRequestsEmPrSt();
        List<AssignmentRequests> GetAssignmentRequests();
        List<Project> GetAllProjects();
        List<Employee> GetAllEmployees();
        Status GetStatusName(int id);



    }
}
