using Application.Features.Students.Commands.CreateStudent;
using Domain.Entities.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.Students
{
    public interface IStudentRepositary
    {
        Task<Student> create(CreateStudentCommand command);
    }
}
