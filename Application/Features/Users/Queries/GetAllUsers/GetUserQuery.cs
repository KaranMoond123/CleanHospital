using Application.Dto.users;
using Application.Interfaces.UnitOfWorkRepositories;
using AutoMapper;
using Domain.Entities.Users;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetAllUsers
{
    public class GetUserQuery:IRequest<Result<List<GetUserDto>>>
    {
    }
    internal class GetUserQueryHandler : IRequestHandler<GetUserQuery, Result<List<GetUserDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetUserDto>>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repositary<User>().GetAll();
            if(data == null)
            {
                return Result<List<GetUserDto>>.NotFound("Sorry Data Not Found");
            }
            var mapdata=_mapper.Map<List<GetUserDto>>(data);
            return Result<List< GetUserDto>>.Success(mapdata, "User Data");

        }
    }
}
