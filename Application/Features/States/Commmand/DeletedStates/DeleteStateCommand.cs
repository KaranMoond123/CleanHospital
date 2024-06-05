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

namespace Application.Features.States.Commmand.DeletedStates;

public class DeleteStateCommand:IRequest<Result<int>>
{
    public int Id { get; set; }
    public DeleteStateCommand(int id)
    {
        Id = id;
    }
}
internal class DeleteCommandHandler : IRequestHandler<DeleteStateCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(DeleteStateCommand request, CancellationToken cancellationToken)
    {
       var data=await _unitOfWork.Repositary<State>().GetByID(request.Id);
        if (data==null)
        {
            return Result<int>.BadRequest($"Sorry Id{request.Id} not found");
        }
        var mapdata=_mapper.Map<State>(data);
        await _unitOfWork.Repositary<State>().DeleteAsync(mapdata);
        await _unitOfWork.Save(cancellationToken);
        return Result<int>.Success("Data Deleted");
    }
}
