using Application.Interfaces.Repositories.Staffs;
using Application.Interfaces.UnitOfWorkRepositories;
using AutoMapper;
using Domain.Entities.staffs;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Staffs.Commands.CreateStaffs
{
    public class CreateStaffCommand:IRequest<Result<int>>
    {
        public string FastName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public CreateStaffCommand(string fastName, string lastName, string description, string city, string state, string country)
        {
            FastName = fastName;
            LastName = lastName;
            Description = description;
            City = city;
            State = state;
            Country = country;
        }
    }
    internal class CreateStaffCommandHandler : IRequestHandler<CreateStaffCommand, Result<int>>
    {
        private readonly IStafffRepositary _stafffRepositary;

        public CreateStaffCommandHandler(IStafffRepositary stafffRepositary)
        {
            _stafffRepositary = stafffRepositary;
        }

        public async Task<Result<int>> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
        {
             
            var data = await _stafffRepositary.create(request);
            return Result<int>.Success("Created Succesfully");
           
        }
    }
}
