using Application.Dto.Loopup;
using Application.Interfaces.UnitOfWorkRepositories;
using AutoMapper;
using Domain.Entities.Countries;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Countries.Commands.UpdateCountries;

public class UpdateCountryCommand : IRequest<Result<LookupDto>>
{
    public int ID { get; set; }
    public CreateCommandCountry CreateCommandCountry { get; set; }
    public UpdateCountryCommand(int iD, CreateCommandCountry createCommandCountry)
    {
        ID = iD;
        CreateCommandCountry = createCommandCountry;
    }
}
internal class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Result<LookupDto>>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateCountryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<LookupDto>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var data=await _unitOfWork.Repositary<Country>().GetByID(request.ID);
        if(data == null)
        {
            return Result<LookupDto>.BadRequest($"Sorry update {request.ID} not Find");
        }
        var mapdata = _mapper.Map(request.CreateCommandCountry, data);
        await _unitOfWork.Repositary<Country>().UpdateAsync(mapdata,request.ID);
        await _unitOfWork.Save(cancellationToken);
        return Result<LookupDto>.Success("Data Update");    
    }
}
