using ProjectLeader.Models;
using ProjectLeader.Models.HelperModels;
using ProjectLeader.Models.AssignmentHelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.Service
{
    public interface IProjectService
    {
        ProjectHelperModel GetProject(Guid id);
        IResponse<List<ProjectManagement>> GetProjectManagement();

        IResponse<List<ProjectAssignments>> GetProjectAssignment();
        IResponse<NoValue> AddProject(ProjectHelperModel model);
        IResponse<NoValue> EditProject(ProjectHelperModel model);
        IResponse<NoValue> DeleteProject(Project project);

        IResponse<NoValue> AddToProject(ProjectHelperModel modelAssignment);
        IResponse<NoValue> RemoveProject(ProjectHelperModel model);
        ProjectHelperModel GetModal();
        Project GetProjectById(Guid id);
    }
}
