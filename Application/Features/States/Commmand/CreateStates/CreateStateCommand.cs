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

namespace Application.Features.States.Commmand.CreateStates;

public class CreateStateCommand:IRequest<Result<int>>
{
    public string Name {  get; set; }
    public int CountryId {  get; set; }

}
internal class CreateStateCommandHandler : IRequestHandler<CreateStateCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateStateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(CreateStateCommand request, CancellationToken cancellationToken)
    {
        var mapdata=_mapper.Map<State>(request);
        var data=await _unitOfWork.Repositary<State>().AddAsync(mapdata);
        await _unitOfWork.Save(cancellationToken);
        return Result<int>.Success("Inserted.....");
    }
}

