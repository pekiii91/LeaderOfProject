using ProjectLeader.Models;
using ProjectLeader.Models.EmployeeHelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.Service
{
    public interface IEmployeeService
    {
        IResponse<List<EmployeeHelperModels>> GetAll();
        IResponse<NoValue> Add(Employee employee);
        IResponse<NoValue> Edit(Employee employee);
        IResponse<NoValue> DeleteEmployee(Employee employee);
        EmployeeHelperModels EmployeeGetModal();
        EmployeeHelperModels GetEmployee(Guid id);
        Employee GetEmployeeById(Guid id);
    }
}
