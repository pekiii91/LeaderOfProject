using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectLeader.Helpers;
using ProjectLeader.Models;
using ProjectLeader.Models.AssignmentHelperModels;
using ProjectLeader.Models.HelperModels;
using ProjectLeader.Unit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectLeader.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _uow;
        private readonly EmailHelper _emailHelper;
        public ProjectService(IUnitOfWork uow, EmailHelper emailHelper)
        {
            _uow = uow;
            _emailHelper = emailHelper;
        }

        public IResponse<List<ProjectManagement>> GetProjectManagement()
        {
            var response = new Response<List<ProjectManagement>>();
            try
            {
                var allProject = _uow.ProjectRepository.GetProjectsWithPL().Select(p => new ProjectManagement
                {
                    Id = p.Id,
                    Name = p.Name,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,
                    Path = p.Path,
                    ProjectLead = p.ProjectLead.FirstName + " " + p.ProjectLead.LastName,
                    Status = p.Status.StatusName
                }).ToList();

                if (allProject.Count > 0)
                {
                    response.Value = allProject;
                    response.Status = StatusEnum.Success;
                }
                else
                {
                    response.Value = allProject;
                    response.Status = StatusEnum.Success;
                    response.Message = "No data found";
                }

            }
            catch (Exception ex)
            {
                response.Status = StatusEnum.Failed;
                response.Message = "Something went wrong. Please try again later...";
            }
            return response;
        }

        public IResponse<List<ProjectAssignments>> GetProjectAssignment()
        {
            var response = new Response<List<ProjectAssignments>>();
            try
            {

                

                var allProject = _uow.ProjectRepository.GetProjectsWithPL().Select(p => new ProjectAssignments
                {
                    Id = p.Id,
                    FirstName = p.ProjectLead.FirstName,
                    LastName = p.ProjectLead.LastName,
                    Project = p.Name
                }).ToList();

                if (allProject.Count > 0)
                {
                    response.Value = allProject;
                    response.Status = StatusEnum.Success;
                }
                else
                {
                    response.Value = allProject;
                    response.Status = StatusEnum.Success;
                    response.Message = "No data found";
                }

            }
            catch (Exception ex)
            {
                response.Status = StatusEnum.Failed;
                response.Message = "Something went wrong. Please try again later..";
            }
            return response;  //vraca kao rezultat druge API operacije 

        }

        public ProjectHelperModel GetProject(Guid id)
        {
            Project project = _uow.ProjectRepository.Get(id);
            ProjectHelperModel projectHelper = new ProjectHelperModel
            {
                Id = project.Id,
                Name = project.Name,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Path = project.Path,
                ProjectLeadId = project.ProjectLeadId,
                StatusId = project.StatusId,
                StatusList = _uow.ProjectRepository.GetAllStatus().Select(s => new SelectListItem {
                    Value = s.StatusId.ToString(),
                    Text = s.StatusName
                }).ToList(),
                EmployeesList = _uow.AllEmployees.Select(e => new SelectListItem {
                    Value = e.Id.ToString(),
                    Text = e.FirstName + " " + e.LastName
                }).ToList()
            };

            return projectHelper;
        }

        public IResponse<NoValue> AddProject(ProjectHelperModel model)
        {
            var response = new Response<NoValue>();
            try
            {
                Project project = new Project
                {
                    Name = model.Name,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Path = model.Path,
                    ProjectLeadId = model.ProjectLeadId,
                    StatusId = model.StatusId

                };
                _uow.ProjectRepository.Add(project); //pozivam metodu iz G.R
                _uow.Complete(); //Add to database

                //Saljemo email, tj. informacije koje dobija zaposleni
                Employee employee = _uow.GetEmployeesById(model.ProjectLeadId);

                EmailModel emailModel = new EmailModel()
                {
                    To = employee.FirstName + employee.LastName + "yopmail.com",
                    Subject = "Project notification",
                    Message = model.Name + " " + employee.FirstName + " " + employee.LastName,
                    IsBodyHtml = false
                };
                var result = _emailHelper.SendEmail(emailModel);
            
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

        public IResponse<NoValue> EditProject(ProjectHelperModel model)
        {
            var response = new Response<NoValue>();
            try
            {
                Project project = new Project
                {
                    Name = model.Name,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Path = model.Path,
                    ProjectLeadId = model.ProjectLeadId,
                    StatusId = model.StatusId

                };
                _uow.ProjectRepository.Update(project);
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

        public IResponse<NoValue> DeleteProject(Project project)
        {
            var response = new Response<NoValue>();
            try
            {
                _uow.ProjectRepository.Remove(project);
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

        // Add To Project from Project Assignment
        public IResponse<NoValue> AddToProject(ProjectHelperModel model)
        {
            var response = new Response<NoValue>();
            try
            {
                Project project = _uow.ProjectRepository.GetProjectsById(model.Id);

                CurrentAssignment currentAssignment = new CurrentAssignment()
                {
                    ProjectId = project.Id,
                    EmployeeId = project.ProjectLeadId,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate
                };
        
                _uow.CurrentAssignmentRepository.Add(currentAssignment); //pozivam metodu iz G.R
                _uow.Complete();
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

        // Remove From Project in the Project Assignment 
        public IResponse<NoValue> RemoveProject(ProjectHelperModel model)
        {
            var response = new Response<NoValue>();
            try
            {
                Project project = _uow.ProjectRepository.GetProjectsById(model.Id);
                CurrentAssignment currentAssignment = new CurrentAssignment()
                {
                    ProjectId = project.Id,
                    EmployeeId = project.ProjectLeadId,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate
                };

                _uow.CurrentAssignmentRepository.Remove(currentAssignment); //pozivam metodu iz G.R
                _uow.Complete();
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

        public ProjectHelperModel GetModal() // za dodavanje liste zaposlenih 
        {
            List<SelectListItem> employees = _uow.AllEmployees.Select(e => new SelectListItem
            {
                Text = e.FirstName + " " + e.LastName,
                Value = e.Id.ToString()
            }).ToList();


            List<SelectListItem> statuses = _uow.ProjectRepository.GetAllStatus().Select(s => new SelectListItem
            {
                Text = s.StatusName,
                Value = s.StatusId.ToString()
            }).ToList();

            var result = new ProjectHelperModel
            {
                StatusList = statuses,
                EmployeesList = employees
            };
            return result;
        }

        public Project GetProjectById(Guid id)
        {
            try
            {
                var dePr = _uow.ProjectRepository.GetProjectsById(id); //  GetProjectsById metoda iz P.R
                return dePr;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        
    }
}


