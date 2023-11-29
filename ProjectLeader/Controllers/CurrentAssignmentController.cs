using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectLeader.Service;
using ProjectLeader.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ProjectLeader.Controllers
{
    [Authorize(Roles = "ProjectLead, DepartmentLead")] 
    public class CurrentAssignmentController : Controller
    {
        private readonly ICurrentAssignmentService _currentAssignmentService;
        private readonly IProjectService _projectService;
        private readonly IEmployeeService _employeeService;

        public CurrentAssignmentController (ICurrentAssignmentService currentAssignmentService, IProjectService projectService, IEmployeeService employeeService)
        {
            _currentAssignmentService = currentAssignmentService;
            _projectService = projectService;
            _employeeService = employeeService;
        }

        //Current Assignments Index Page
        [Authorize(Roles = "ProjectLead, DepartmentLead")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _currentAssignmentService.GetCurrentAssignment();
            ViewBag.title = "CurrentAssignment";
            return View(model.Value);
        }




    }
}
