using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectLeader.Models;
using ProjectLeader.Unit;
using ProjectLeader.InterfaceRepository;
using ProjectLeader.Models.CurrentHelperModels;
using ProjectLeader.Repository;

namespace ProjectLeader.Service
{
    public class CurrentAssignmentService : ICurrentAssignmentService
    {
        private readonly IUnitOfWork _uow;

        public CurrentAssignmentService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //public IResponse<List<RequestedFromMeIndex>> GetCurrentAssignment()
        //{
        //    var response = new Response<List<RequestedFromMeIndex>>();
        //    try
        //    {
        //        var allCurrentAssignments = _uow.CurrentAssignmentRepository.AllCurrentAssignments.Select(ca => new RequestedFromMeIndex
        //        {
        //            RequestedFor =ca.Employee.FirstName,
        //            ToProject = ca.Project.Name,
        //            StartDate = ca.StartDate,
        //            EndDate = ca.EndDate
        //        }).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Status = StatusEnum.Failed;
        //        response.Message = "Something went wrong. Please try again later...";
        //    }
        //    return response;
        //}

        public IResponse<List<CurrentAssignnmentHelperModel>> GetCurrentAssignment()
        {
            var response = new Response<List<CurrentAssignnmentHelperModel>>();
            try
            {
                var allCurrentAssignments = _uow.CurrentAssignmentRepository.GetCurrentAssignmentWithEmPr().Select(ca => new CurrentAssignnmentHelperModel
                {
                    FirstName = ca.Employee.FirstName,
                    LastName = ca.Employee.LastName,
                    Project = ca.Project.Name,
                    StartDate = ca.StartDate,
                    EndDate = ca.EndDate
                }).ToList();

                if (allCurrentAssignments.Count > 0)
                {
                    response.Value = allCurrentAssignments;
                    response.Status = StatusEnum.Success;
                }
                else
                {
                    response.Value = allCurrentAssignments;
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





    }
}
