using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLeader.Models.EmployeeHelperModels
{
    public class EmployeeHelperModels
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public int GenderId { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public List<SelectListItem> GenderList { get; set; }


    }
}
