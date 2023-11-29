using ProjectLeader.Data;
using ProjectLeader.InterfaceRepository;
using ProjectLeader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.Repository
{
    public class StatusRepository : GenericRepository<Status>, IStatusRepository
    {
        public StatusRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public IEnumerable<Status> GetStatusId(int statusId)
        {
            return _applicationDbContext.Statuses.Where(s => s.StatusId == statusId);
        }


    }
}
