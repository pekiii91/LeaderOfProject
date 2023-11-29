using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectLeader.InterfaceRepository;
using Microsoft.AspNetCore.Authorization;
using ProjectLeader.Models;
using ProjectLeader.Service;
using ProjectLeader.Repository;
using ProjectLeader.Models.HelperModels;
using ProjectLeader.Models.AssignmentHelperModels;

namespace ProjectLeader.Controllers
{
    [Authorize(Roles = "DepartmentLead")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IEmployeeService _employeeService;

        public ProjectController(IProjectService projectService, IEmployeeService employeeService)
        {
            _projectService = projectService;
            _employeeService = employeeService;
        }

        //project management Index
        [HttpGet]
        public IActionResult ProjectManagement()
        {
            var model = _projectService.GetProjectManagement();
            ViewBag.title = "Project";
            return View(model.Value);
        }

        //project assignments Index
        [HttpGet]
        public IActionResult ProjectAssignments()
        {
            var model = _projectService.GetProjectAssignment();
            ViewBag.title = "Project";
            return View(model.Value);
        }

        // Add Project Management
        [HttpGet]
        public ActionResult Create()
        {
            var result = _projectService.GetModal();
            return PartialView("_CreatePartialProject", result);
        }

        [HttpPost]
        public ActionResult Create(ProjectHelperModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _projectService.AddProject(model);
                ViewBag.title = "Project";
                return Json(result);
            }
            else
            {
                return View(model);
            }

        }

        //Edit Project Management
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            ProjectHelperModel project = _projectService.GetProject(id);
            return PartialView("_EditPartialProject", project);
        }

        [HttpPost]
        public ActionResult Edit(ProjectHelperModel model)
        {
            if (ModelState.IsValid)
            {

                var result = _projectService.EditProject(model);
                ViewBag.title = "Project";
                return Json(result);
            }
            else
            {

                return View(model);
            }
        }

        //Delete Project Management
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            Project project = _projectService.GetProjectById(id);
            var result = _projectService.DeleteProject(project);
            return Json(result);
        }

        //Add to project
        [HttpPost]
        public ActionResult AddEmployeeToProject(ProjectHelperModel model)
        {
            var result = _projectService.AddToProject(model);
            return Json(result);
           
        }

        //Project Assignment Remove From Project
        [HttpPost]
        public ActionResult DeleteFromProject(ProjectHelperModel model /*Guid id*/)
        {
            var result = _projectService.RemoveProject(model);
            return Json(result);
            //Project project = _projectService.GetProjectById(id);
            //var result = _projectService.RemoveProject(project);
            //return Json(result);
        }

        
    }
}
