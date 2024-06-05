using Application.Interfaces.UnitOfWorkRepositories;
using AutoMapper;
using Domain.Entities.UserLogins;
using Domain.Entities.Users;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.CreateUsers
{
    public class CreateuserCommand:IRequest<Result<int>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public long MobileNo { get; set; }
        public string Password { get; set; }
    }
    internal class CreateuserCommandHandler : IRequestHandler<CreateuserCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateuserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateuserCommand request, CancellationToken cancellationToken)
        {
            var mapdata = _mapper.Map<User>(request);
            var data=await _unitOfWork.Repositary<User>().AddAsync(mapdata);
            await _unitOfWork.Save(cancellationToken);

            var userlogin = new UserLogin
            {
                Code = request.Email,
                Password = request.Password,
                UserId = mapdata.Id
            };
            await _unitOfWork.Repositary<UserLogin>().AddAsync(userlogin);
            await _unitOfWork.Save(cancellationToken);
            return Result<int>.Success("Succcess.......");
        }
    }
}
