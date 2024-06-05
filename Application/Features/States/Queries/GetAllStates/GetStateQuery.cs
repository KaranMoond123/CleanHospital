using Application.Dto.States;
using Application.Interfaces.UnitOfWorkRepositories;
using AutoMapper;
using Domain.Entities.States;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.States.Queries.GetAllStates
{
    public class GetStateQuery:IRequest<Result<List<GetStateDto>>>
    {
    }
    internal class GetStateQueryHandler : IRequestHandler<GetStateQuery, Result<List<GetStateDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetStateQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetStateDto>>> Handle(GetStateQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repositary<State>().GetAll();
            if(data == null)
            {
                return Result<List<GetStateDto>>.BadRequest("Sorry data not Found");
            }
            var mapdata=_mapper.Map<List<GetStateDto>>(data);
            return Result<List<GetStateDto>>.Success(mapdata, "State List..");
        }
    }
}
