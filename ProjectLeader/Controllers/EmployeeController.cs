using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectLeader.Models;
using ProjectLeader.Models.EmployeeHelperModels;
using ProjectLeader.Service;

namespace ProjectLeader.Controllers
{
    [Authorize(Roles = "ProjectLead, DepartmentLead")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _employeeService.GetAll();
            ViewBag.title = "Employee";
            return View(result.Value);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var result = _employeeService.EmployeeGetModal();
            return PartialView("_CreatePartial", result);
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var result = _employeeService.Add(employee);
                ViewBag.title = "Employee";
                return Json(result);

            }
            else
            {
                return View(employee);
            }
        }


        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            EmployeeHelperModels employee = _employeeService.GetEmployee(id); // implementirana u EmployeesRepository
            return PartialView("_EditPartial",  employee);
        }


        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var result = _employeeService.Edit(employee);
                ViewBag.title = "Employee";
                return Json(result);
            }
            else
            {
                return View(employee);
            }

        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            Employee employee = _employeeService.GetEmployeeById(id); // implementirana u EmployeesRepository
            var result = _employeeService.DeleteEmployee(employee);
            return Json(result); 
        }





    }
}
