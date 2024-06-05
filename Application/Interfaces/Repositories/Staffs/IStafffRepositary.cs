using Application.Features.Staffs.Commands.CreateStaffs;
using Domain.Entities.staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.Staffs
{
    public interface IStafffRepositary
    {
        Task<Staff>create(CreateStaffCommand command);
    }
}
