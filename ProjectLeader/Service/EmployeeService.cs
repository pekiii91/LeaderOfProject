using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectLeader.InterfaceRepository;
using ProjectLeader.Models;
using ProjectLeader.Models.EmployeeHelperModels;
using ProjectLeader.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _uow;

        public EmployeeService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public EmployeeHelperModels GetEmployee(Guid id)
        {
            Employee employee = _uow.AllEmployees.Where(e => e.Id == id).FirstOrDefault();
            EmployeeHelperModels result = new EmployeeHelperModels {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth.ToString(),
                GenderId = employee.GenderId,
                City = employee.City,
                State = employee.State,
                GenderList = _uow.GetAllGendes().Select(g => new SelectListItem
                {
                    Text = g.Code,
                    Value = g.Id.ToString()
                }).ToList(),
            };
            return result;
        }

        public IResponse<List<EmployeeHelperModels>> GetAll()
        {
            var response = new Response<List<EmployeeHelperModels>>();
            try
            {
                List<Employee> allEmployee = _uow.AllEmployees.ToList();
                List<EmployeeHelperModels> listEmployees = new List<EmployeeHelperModels>();
                listEmployees = allEmployee.Select(e => new EmployeeHelperModels
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    DateOfBirth = e.DateOfBirth.ToString("dd//MM/yyyy"),
                    GenderId = e.GenderId,
                    City = e.City,
                    State = e.State
                }).ToList();
                if (allEmployee.Count > 0)
                {
                    response.Value = listEmployees;
                    response.Status = StatusEnum.Success;
                }
                else
                {
                    response.Value = listEmployees;
                    response.Status = StatusEnum.Success;
                    response.Message = "No data found";
                }
            }
            catch (Exception ex)
            {
                response.Status = StatusEnum.Failed;
                response.Message = "Something work wrong. Please try again later...";
            }
            return response;
        }

        public IResponse<NoValue> Add(Employee employee)
        {
            var response = new Response<NoValue>();
            try
            {
                _uow.EmployeeRepository.Add(employee); //dodavanje u bazu
                _uow.Complete(); //sacuvaj u bazu 
                response.Status = StatusEnum.Success;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Status = StatusEnum.Failed;
                response.Message = "Something went wrong. Please try again later...";
            }
            return response;
        }

        public IResponse<NoValue> Edit(Employee employee)
        {
            var response = new Response<NoValue>();
            try
            {
                _uow.EmployeeRepository.Update(employee);
                _uow.Complete();
                response.Status = StatusEnum.Success;
                response.Message = "Success";

            }
            catch (Exception ex)
            {
                response.Status = StatusEnum.Failed;
                response.Message = "Something went wrong. Please try again later..";
            }

            return response;
        }

        public IResponse<NoValue> DeleteEmployee(Employee employee)
        {
            var response = new Response<NoValue>();
            try
            {
                _uow.EmployeeRepository.Remove(employee);
                _uow.Complete();
                response.Status = StatusEnum.Success;
                response.Message = "Success";

            }
            catch (Exception ex)
            {
                response.Status = StatusEnum.Failed;
                response.Message = "Cancel";
            }
            return response;
        }

        public Employee GetEmployeeById(Guid id)
        {
            try
            {
                var deEm = _uow.GetEmployeesById(id);
                return deEm;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public EmployeeHelperModels EmployeeGetModal()
        {
            List<Gender> genders = _uow.GetAllGendes();

            List<SelectListItem> genderList = new List<SelectListItem>();

            foreach (var g in genders)
            {
                genderList.Add(new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.Code
                });
            }
           
            var result = new EmployeeHelperModels
            {
                GenderList = genderList 
            };
            return result;
        }

    }
}
