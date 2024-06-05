using Application.Features.Staffs.Commands.CreateStaffs;
using Application.Interfaces.Repositories.Staffs;
using AutoMapper;
using Domain.Entities.staffs;
using Peristance.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peristance.Extenstion.Repositories.Staffs
{
    public class StaffRepositary : IStafffRepositary
    {
        private readonly ApplicationdbContext _context;
        public readonly IMapper _mapper;

        public StaffRepositary(ApplicationdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Staff> create(CreateStaffCommand command)
        {
           var mapdata=_mapper.Map<Staff>(command);

            var data=await _context.Stants.AddAsync(mapdata);
            await _context.SaveChangesAsync();
            return mapdata;
        }
    }
}
