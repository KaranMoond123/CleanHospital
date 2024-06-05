using Application.Interfaces.Jwtservices;
using Application.Interfaces.UnitOfWorkRepositories;
using AutoMapper;
using Domain.Entities.UserLogins;
using Domain.Entities.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Application.Features.Users.Commands.Logins
{
    public class CreateLoginCommand : IRequest<Result<int>>
    {
        public string Code { get; set; }
        public string Password { get; set; }
    }

    internal class CreateLoginCommandHandler : IRequestHandler<CreateLoginCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IJwsService _jwtService;
        public CreateLoginCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IJwsService jwtService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtService = jwtService;
        }
        public async Task<Result<int>> Handle(CreateLoginCommand request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repositary<User>().Entities.Where(x => x.Email == request.Code && x.IsDeleted == false).FirstOrDefaultAsync();
            if (data == null)
            {
                return Result<int>.BadRequest("Invalid Code..");
            }
            var userLogin = await _unitOfWork.Repositary<UserLogin>().Entities.Where(x => x.Code == request.Code && x.Password == request.Password).FirstOrDefaultAsync();
            if (userLogin == null)
            {
                return Result<int>.BadRequest("Invalid Password..");
            }

            var token = await _jwtService.GenrateJwt(userLogin.UserId);
            return Result<int>.Success(userLogin.UserId, "Login SuccessFully", token);
        }
    }
}
