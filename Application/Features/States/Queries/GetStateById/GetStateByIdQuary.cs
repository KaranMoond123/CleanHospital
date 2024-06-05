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

namespace Application.Features.States.Queries.GetStateById;

public class GetStateByIdQuary:IRequest<Result<GetStateDto>>
{
    public int Id { get; set; }
    public GetStateByIdQuary(int id)
    {
        Id = id;
    }
}
internal class GetStateByIdQuaryHandler : IRequestHandler<GetStateByIdQuary, Result<GetStateDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetStateByIdQuaryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<GetStateDto>> Handle(GetStateByIdQuary request, CancellationToken cancellationToken)
    {
       var data=await _unitOfWork.Repositary<State>().GetByID(request.Id);
        if(data == null)
        {
            return Result<GetStateDto>.BadRequest($"Sorry Id{request.Id} not Found");
        }
        var mapdata=_mapper.Map<GetStateDto>(data);
        return Result<GetStateDto>.Success(mapdata,"State data");
    }
}
