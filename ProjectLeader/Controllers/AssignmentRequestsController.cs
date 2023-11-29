using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectLeader.Service;
using ProjectLeader.Models;
using ProjectLeader.Models.CurrentHelperModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using ProjectLeader.Data;
using System.Web;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace ProjectLeader.Controllers
{
    [Authorize(Roles = "ProjectLead, DepartmentLead")]
    public class AssignmentRequestsController : Controller
    {
        private readonly IAssignmentRequestsService _assignmentRequestsService;
        private readonly IEmployeeService _employeeService;
        private readonly IProjectService _projectService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ApplicationDbContext _applicationDbContext;


        public AssignmentRequestsController(IAssignmentRequestsService assignmentRequestsService, IEmployeeService employeeService,
            IProjectService projectService, UserManager<ApplicationUser> userManager, ApplicationDbContext applicationDbContext, RoleManager<Role> roleManager)
        {
            _assignmentRequestsService = assignmentRequestsService;
            _employeeService = employeeService;
            _projectService = projectService;
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
            _roleManager = roleManager;
        }


        //AssignmentRequests Index Page
        [HttpGet]
        public IActionResult AssignmentRequestsIndex()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            IResponse<List<AssignmentRequestsIndex>> result = _assignmentRequestsService.GetAssignmentRequests(userId); //user id
             //   var test = _userManager.IsInRoleAsync(user, "ProjectLead", "DepartmentLead");
            ViewBag.title = "AssignmentRequests";
            return View(result.Value);

        }


        [HttpGet]
        public IActionResult RequestedFromMeIndex()
        {
            IResponse<List<RequestedFromMeIndex>> result = _assignmentRequestsService.GetRequestsFromMe(); //user id
            ViewBag.title = "AssignmentRequests";
            return View(result.Value);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var result = _assignmentRequestsService.GetAssignmentModal();
            return PartialView("_CreatePartialRequests", result);
        }


        [HttpPost]
        public ActionResult Create(AssignmentHelperModel model)
        {
            if (ModelState.IsValid)
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                //string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                var result = _assignmentRequestsService.AddAssignmentRequests(model, userId);
                ViewBag.title = "AssignmentRequests";
                return Json(result);
            }
            else
            {
                return View(model);
            }

        }

        //Approve
        [HttpPost]
        public ActionResult ApproveRequest(AssignmentHelperModel model)
        {
            var result = _assignmentRequestsService.UpdateStatusApproveRequest(model);
            return Json(result);
        }


        //Decline
        [HttpPost]
        public ActionResult DeclineRequest(AssignmentHelperModel model)
        {
            var result = _assignmentRequestsService.DeclineStatusRequest(model);
            return Json(result);
        }


    }
}
