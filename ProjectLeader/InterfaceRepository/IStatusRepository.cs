using ProjectLeader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.InterfaceRepository
{
    public interface IStatusRepository : IGenericRepository<Status>
    {
        IEnumerable<Status> GetStatusId(int statusId);
    }
}
