using Microsoft.EntityFrameworkCore;
using ProjectLeader.Data;
using ProjectLeader.InterfaceRepository;
using ProjectLeader.Models;
using ProjectLeader.Models.EmployeeHelperModels;
using ProjectLeader.Models.HelperModels;
using ProjectLeader.Repository;
using ProjectLeader.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.Unit
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;
       
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;


            EmployeeRepository = new EmployeeRepository(_applicationDbContext);
            ProjectRepository = new ProjectRepository(_applicationDbContext);
            StatusRepository = new StatusRepository(_applicationDbContext);
            CurrentAssignmentRepository = new CurrentAssignmentRepository(_applicationDbContext);
            AssignmentRequestsRepository = new AssignmentRequestsRepository(_applicationDbContext);
            ApplicationUserRepository = new ApplicationUserRepository(_applicationDbContext);
        }

        public IEmployeeRepository EmployeeRepository { get; private set; }
        public IProjectRepository ProjectRepository { get; private set; }
        public IStatusRepository StatusRepository { get; private set; }
        public ICurrentAssignmentRepository CurrentAssignmentRepository { get; private set; }
        public IAssignmentRequestsRepository AssignmentRequestsRepository { get; private set; }
        public IApplicationUserRepository ApplicationUserRepository { get; private set; }



      //  Employee
        public IEnumerable<Employee> AllEmployees => _applicationDbContext.Employees;

        public Employee GetEmployeesById(Guid id)
        {
            return _applicationDbContext.Employees.Where(e => e.Id == id).FirstOrDefault();
        }

        public List<Gender> GetAllGendes()
        {
           return _applicationDbContext.Genders.ToList();
        }

        public void Edit(Employee employee)
        {
            try
            {
                var empToEdit = _applicationDbContext.Employees.Find(employee.Id);

                empToEdit.FirstName = employee.FirstName;
                empToEdit.LastName = employee.LastName;
                empToEdit.Email = employee.Email;
                empToEdit.DateOfBirth = employee.DateOfBirth;
                empToEdit.GenderId = employee.GenderId;
                empToEdit.City = employee.City;
                empToEdit.State = employee.State;
                empToEdit.Gender = empToEdit.Gender;

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public void DeleteEmployee(Employee employee)
        {
            _applicationDbContext.Employees.Remove(employee);
        }



        public int Complete()
        {
            return _applicationDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _applicationDbContext.Dispose();
        }
    }
}
