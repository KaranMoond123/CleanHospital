using Application.Features.Students.Commands.CreateStudent;
using Application.Interfaces.Repositories.Students;
using AutoMapper;
using Domain.Entities.Students;
using Peristance.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peristance.Extenstion.Repositories.Students
{
    public class StudentRepositary : IStudentRepositary
    {
        private readonly ApplicationdbContext _dbContext;
        private readonly IMapper _mapper;

        public StudentRepositary(ApplicationdbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Student> create(CreateStudentCommand command)
        {
            long.Parse(command.MobileNo);
           var mapdata=  _mapper.Map<Student>(command);
            var data=await _dbContext.Students.AddAsync(mapdata);
            await _dbContext.SaveChangesAsync();
            return mapdata;
                
        }
    }
}
