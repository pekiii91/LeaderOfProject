using ProjectLeader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.InterfaceRepository
{
    public interface ICurrentAssignmentRepository : IGenericRepository<CurrentAssignment>
    {
        IEnumerable<CurrentAssignment> AllCurrentAssignments { get; }
        CurrentAssignment GetCurrentAssignmentById(Guid id);
        List<CurrentAssignment> GetCurrentAssignments();

        List<CurrentAssignment> GetCurrentAssignmentWithEmPr();
        


    }
}
