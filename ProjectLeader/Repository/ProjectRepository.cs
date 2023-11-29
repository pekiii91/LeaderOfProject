using Microsoft.EntityFrameworkCore;
using ProjectLeader.Data;
using ProjectLeader.InterfaceRepository;
using ProjectLeader.Models;
using ProjectLeader.Models.AssignmentHelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.Repository
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {

        public ProjectRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public IEnumerable<Project> AllProjects => _applicationDbContext.Projects;
        public Project GetProjectsById(Guid id)
        {
            return _applicationDbContext.Projects.Where(p => p.Id == id).FirstOrDefault();
        }

        public List<Project> GetProjectsWithPL()
        {
            return _applicationDbContext.Projects.Include(p => p.ProjectLead).Include(p => p.Status).ToList();
        }

        public List<Project> GetProjectManagements()
        {
            return _applicationDbContext.Set<Project>().ToList();
        }
        public List<Project> GetProjectAssignment()
        {
            return _applicationDbContext.Projects.ToList();
        }

        public List<Status> GetAllStatus()
        {
            return _applicationDbContext.Statuses.ToList();
        }


        public Project GetEmployeeForProject(Guid employeeId) //trazi Id Projecta u tabeli Assignments Requests za FromProject
        {
            return _applicationDbContext.Projects.Where(a => a.ProjectLeadId == employeeId).FirstOrDefault();
        }

    }
}
