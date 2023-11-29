using ProjectLeader.Models;
using ProjectLeader.Models.AssignmentHelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.InterfaceRepository
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        IEnumerable<Project> AllProjects { get; }
        List<Project> GetProjectManagements();
        List<Project> GetProjectAssignment();
        Project GetProjectsById(Guid id);
        List<Status> GetAllStatus();
        List<Project> GetProjectsWithPL();

        Project GetEmployeeForProject(Guid employeeId);      // void AddtoProjects(Project modelAssignment);
    }
}
