using ProjectLeader.InterfaceRepository;
using ProjectLeader.Models;
using ProjectLeader.Models.EmployeeHelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.Unit
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; }
        IProjectRepository ProjectRepository { get; }
        IStatusRepository StatusRepository { get; }
        ICurrentAssignmentRepository CurrentAssignmentRepository { get; }
        IAssignmentRequestsRepository AssignmentRequestsRepository { get; }
        IApplicationUserRepository ApplicationUserRepository { get; }

        IEnumerable<Employee> AllEmployees { get; }

        Employee GetEmployeesById(Guid id);

        List<Gender> GetAllGendes();
        
        void Edit(Employee employee);

        void DeleteEmployee(Employee employee);



        int Complete();

    }
}
