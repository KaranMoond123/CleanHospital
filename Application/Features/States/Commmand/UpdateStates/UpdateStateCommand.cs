using Application.Dto.States;
using Application.Features.States.Commmand.CreateStates;
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

namespace Application.Features.States.Commmand.UpdateStates;

public class UpdateStateCommand:IRequest<Result<GetStateDto>>
{
    public int ID { get; set; }
    public CreateStateCommand CreateStateCommand { get; set; }
    public UpdateStateCommand(int id, CreateStateCommand createStateCommand)
    {
        ID = id;
        CreateStateCommand = createStateCommand;
    }
}
internal class UpdateStateCommandHandler : IRequestHandler<UpdateStateCommand, Result<GetStateDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateStateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<GetStateDto>> Handle(UpdateStateCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.Repositary<State>().GetByID(request.ID);
       if(data == null)
        {
            return Result<GetStateDto>.BadRequest($"Sorry Id={request.ID} Not Found");
        } 
       var mapdata=_mapper.Map(request.CreateStateCommand , data);
        await _unitOfWork.Repositary<State>().UpdateAsync(mapdata,request.ID);
        await _unitOfWork.Save(cancellationToken);
        return Result<GetStateDto>.Success("Data Updated....");
    }
}
