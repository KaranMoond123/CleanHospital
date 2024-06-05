using Application.Interfaces.Repositories.Students;
using Application.Interfaces.UnitOfWorkRepositories;
using AutoMapper;
using Domain.Entities.Students;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommand:IRequest<Result<int>>
    {
        [Required]
        public string Name { get; set; }
        [Range(0,100,ErrorMessage ="Marks in not Range")]
        public string Marks { get; set; }
        [Phone(ErrorMessage ="Phone Number is not Forment")]
        public string MobileNo { get; set; }
        [EmailAddress(ErrorMessage ="Email is not Forment")]
        public string Email { get; set; }

        public CreateStudentCommand(string email, string mobileNo, string marks, string name)
        {
            Email = email;
            MobileNo = mobileNo;
            Marks = marks;
            Name = name;
        }
    }
    internal class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IStudentRepositary _studentRepositary;

        public CreateStudentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IStudentRepositary studentRepositary)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _studentRepositary = studentRepositary;
        }

        public async Task<Result<int>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepositary.create(request);
            if (student == null)
            {
                return Result<int>.BadRequest("Invalid Request");
            }
            return Result<int>.Success("Inserted........");

        }
    }
}
