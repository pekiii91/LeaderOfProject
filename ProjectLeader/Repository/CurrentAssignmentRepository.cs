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
    public class CurrentAssignmentRepository : GenericRepository<CurrentAssignment>, ICurrentAssignmentRepository
    {
        public CurrentAssignmentRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public IEnumerable<CurrentAssignment> AllCurrentAssignments => _applicationDbContext.CurrentAssignments;

        public CurrentAssignment GetCurrentAssignmentById(Guid id)
        {
            return _applicationDbContext.CurrentAssignments.Where(ca => ca.EmployeeId == id).Where(ca => ca.ProjectId == id).FirstOrDefault();
        }

        public List<CurrentAssignment> GetCurrentAssignments()
        {
            return _applicationDbContext.CurrentAssignments.ToList();
        }

        public List<CurrentAssignment> GetCurrentAssignmentWithEmPr()
        {
            return _applicationDbContext.CurrentAssignments.Include(ca => ca.Project).Include(ca => ca.Employee).ToList();
        }



    }
}
