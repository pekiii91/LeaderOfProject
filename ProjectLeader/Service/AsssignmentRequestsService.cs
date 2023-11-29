using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectLeader.Unit;
using ProjectLeader.Models;
using ProjectLeader.Models.CurrentHelperModels;
using ProjectLeader.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Net;
using ProjectLeader.Helpers;

namespace ProjectLeader.Service
{
    public class AsssignmentRequestsService : IAssignmentRequestsService
    {
        private readonly IUnitOfWork _uow;


        public AsssignmentRequestsService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public AssignmentHelperModel GetAssignment(Guid id)
        {
            AssignmentRequests assignmentRequests = _uow.AssignmentRequestsRepository.Get(id);
            AssignmentHelperModel assignmentHelperModel = new AssignmentHelperModel
            {
                Id = assignmentRequests.Id,
                EmployeeAddressed = assignmentRequests.AddressedTo, 
                EmployeeRequested = assignmentRequests.RequestedFor,
                EmployeeCreated = assignmentRequests.CreatedBy,
                ProjectFrom = assignmentRequests.FromProject,
                ProjectTo = assignmentRequests.ToProject,
                StartDate = assignmentRequests.StartDate,
                EndDate = assignmentRequests.EndDate,
                StatusId = assignmentRequests.StatusId,
                StatusList = _uow.ProjectRepository.GetAllStatus().Select(s => new SelectListItem
                {
                    Value = s.StatusId.ToString(),
                    Text = s.StatusName
                }).ToList(),
                EmployeesList = _uow.AssignmentRequestsRepository.GetAllEmployees().Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.FirstName + " " + e.LastName
                }).ToList(),
                ProjectsList = _uow.AssignmentRequestsRepository.GetAllProjects().Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name 
                }).ToList()
            };
            return assignmentHelperModel;
        }

        public IResponse<List<AssignmentRequestsIndex>> GetAssignmentRequests(string id)
        {
            var response = new Response<List<AssignmentRequestsIndex>>();
            try
            {
                var allAssignmentRequests = _uow.AssignmentRequestsRepository.GetAssignmentRequestsEmPrSt().Select(a => new AssignmentRequestsIndex {
                    Id = a.Id,
                    AddressedTo = a.EmployeeAddressed.FirstName + " " + a.EmployeeAddressed.LastName,
                    RequestedFor = a.EmployeeRequested.FirstName + " " + a.EmployeeRequested.LastName,
                    CreatedBy = new Guid(id),
                    FromProject = a.ProjectFrom.Name,
                    ToProject = a.ProjectTo.Name,
                    StartDate = a.StartDate,
                    EndDate = a.EndDate,
                    Status = a.Status.StatusName
                }).ToList();

            if (allAssignmentRequests.Count > 0)
                {
                    response.Value = allAssignmentRequests;
                    response.Status = StatusEnum.Success;
                }
                else
                {
                    response.Value = allAssignmentRequests;
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

        public IResponse<List<RequestedFromMeIndex>> GetRequestsFromMe()
        {
            var response = new Response<List<RequestedFromMeIndex>>();
            try
            {
                //var assignmentRequests = _uow.AssignmentRequestsRepository.GetAll();
                //var test = assignmentRequests.Where(a => a.StatusId == Id).
                //assignmentRequests.StatusId = (int)StatusEnum.IsExist;

                var allAssignmentRequests = _uow.AssignmentRequestsRepository.GetAssignmentRequestsEmPrSt().Select(a => new RequestedFromMeIndex
                {
                    Id = a.Id,
                    RequestedFrom= a.EmployeeAddressed.FirstName + " " + a.EmployeeAddressed.LastName,
                    RequestedFor = a.EmployeeRequested.FirstName + " " + a.EmployeeRequested.LastName,
                    FromProject = a.ProjectFrom.Name,
                    ToProject = a.ProjectTo.Name,
                    StartDate = a.StartDate,
                    EndDate = a.EndDate,
                    Status = a.Status.StatusName
                }).ToList();

                if (allAssignmentRequests.Count > 0)
                {
                    response.Value = allAssignmentRequests;
                    response.Status = StatusEnum.Success;
                }
                else
                {
                    response.Value = allAssignmentRequests;
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

        public IResponse<NoValue> AddAssignmentRequests(AssignmentHelperModel model, string id)
        {
            var response = new Response<NoValue>();
            try
            {
              
                AssignmentRequests assignmentRequests = new AssignmentRequests
                {
                    AddressedTo = model.EmployeeAddressed, // AddressedTo == RequestedFrom
                    RequestedFor = model.EmployeeRequested,
                    CreatedBy = new Guid(id),
                    FromProject = model.ProjectFrom,
                    ToProject = model.ProjectTo,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    StatusId = model.StatusId
                };
                _uow.AssignmentRequestsRepository.Add(assignmentRequests);
                _uow.Complete();
                response.Status = StatusEnum.Success;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Status = StatusEnum.Failed;
                response.Message = "Something went wrong. Please later again...";
            }
            return response;
        }

        public IResponse<NoValue> UpdateStatusApproveRequest(AssignmentHelperModel model)
        {
            var response = new Response<NoValue>();
            try
            {
                //promenili smo Status polje
                AssignmentRequests assignmentRequests = _uow.AssignmentRequestsRepository.GetAssignmentRequestsById(model.Id);

                assignmentRequests.Status = _uow.AssignmentRequestsRepository.GetStatusName(assignmentRequests.StatusId);
                assignmentRequests.StatusId = (int)StatusEnum.Success;
                CurrentAssignment currentAssignment = new CurrentAssignment()
                {
                    EmployeeId = assignmentRequests.RequestedFor,
                    ProjectId = assignmentRequests.ToProject,
                    StartDate = assignmentRequests.StartDate,
                    EndDate = assignmentRequests.EndDate
                };
                _uow.CurrentAssignmentRepository.Add(currentAssignment);
                _uow.Complete();
                response.Status = StatusEnum.Success;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Status = StatusEnum.Failed;
                response.Message = "Something went wrong. Please later again...";
            }
            return response;
        }

        public IResponse<NoValue> DeclineStatusRequest(AssignmentHelperModel model)
        {
            var response = new Response<NoValue>();
            try
            {
                AssignmentRequests assignmentRequests = _uow.AssignmentRequestsRepository.GetAssignmentRequestsById(model.Id);

                assignmentRequests.Status = _uow.AssignmentRequestsRepository.GetStatusName(assignmentRequests.StatusId);
                assignmentRequests.StatusId = (int)StatusEnum.Failed;

                //CurrentAssignment currentAssignment = new CurrentAssignment
                //{
                //    EmployeeId = assignmentRequests.RequestedFor,
                //    ProjectId = assignmentRequests.ToProject,
                //    StartDate = assignmentRequests.StartDate,
                //    EndDate = assignmentRequests.EndDate
                //};

                _uow.Complete();
                response.Status = StatusEnum.Success;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Status = StatusEnum.Failed;
                response.Message = "Something went wrong. Please later again...";
            }
            return response;
        }

        public AssignmentHelperModel GetAssignmentModal()
        {
            List<SelectListItem> employees = _uow.AssignmentRequestsRepository.GetAllEmployees().Select(e => new SelectListItem
            {
                Text = e.FirstName + " " + e.LastName,
                Value = e.Id.ToString()
            }).ToList();

            List<SelectListItem> statuses = _uow.ProjectRepository.GetAllStatus().Select(s => new SelectListItem
            {
                Text = s.StatusName,
                Value = s.StatusId.ToString()
            }).ToList();

            List<SelectListItem> projects = _uow.AssignmentRequestsRepository.GetAllProjects().Select(p => new SelectListItem
            {
               Text = p.Name,
               Value = p.Id.ToString()
            }).ToList();

            var result = new AssignmentHelperModel
            {
                EmployeesList = employees,
                StatusList = statuses,
                ProjectsList = projects
            };
            return result;
        }


    }
}
