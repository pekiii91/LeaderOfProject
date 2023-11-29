using Microsoft.EntityFrameworkCore;
using ProjectLeader.Data;
using ProjectLeader.InterfaceRepository;
using ProjectLeader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProjectLeader.Repository
{
    public class AssignmentRequestsRepository : GenericRepository<AssignmentRequests>, IAssignmentRequestsRepository
    {

        public AssignmentRequestsRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
        public IEnumerable<AssignmentRequests> AllAssignmentRequests => _applicationDbContext.AssignmentRequests;

        public AssignmentRequests GetAssignmentRequestsById(Guid id)
        {
            return _applicationDbContext.AssignmentRequests.Where(a => a.Id == id).FirstOrDefault();
        }

        //vezemo tri reference
        public List<AssignmentRequests> GetAssignmentRequestsEmPrSt()
        {
            return _applicationDbContext.AssignmentRequests.Include(a => a.EmployeeAddressed).Include(a => a.EmployeeRequested).Include(a => a.ProjectFrom)
               .Include(a => a.ProjectTo).Include(a => a.Status).ToList();
        }

        public List<AssignmentRequests> GetAssignmentRequests()
        {
            return _applicationDbContext.Set<AssignmentRequests>().ToList();
        }

        //pozivam sve Project
        public List<Project> GetAllProjects()
        {
            return _applicationDbContext.Projects.ToList();
        }

        //pozivam sve Employee
        public List<Employee> GetAllEmployees()
        {
            return _applicationDbContext.Employees.ToList();
        }

        //pronalazim StatusName
        public Status GetStatusName(int id)
        {
            return _applicationDbContext.Statuses.Where(s=> s.StatusId == id).FirstOrDefault();
        }


    }
}
