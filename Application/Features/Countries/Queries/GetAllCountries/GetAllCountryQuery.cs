using Application.Dto.Loopup;
using Application.Interfaces.UnitOfWorkRepositories;
using AutoMapper;
using Domain.Entities.Countries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Countries.Queries.GetAllCountries
{
    public class GetAllCountryQuery:IRequest<Result<List<LookupDto>>>
    {
    }
    internal class GetAllCountryQueryHandler : IRequestHandler<GetAllCountryQuery, Result<List<LookupDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllCountryQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<LookupDto>>> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repositary<Country>().GetAll();
            if(data == null)
            {
                return Result<List<LookupDto>>.NotFound("Data not found..");
            }
            var mapData=_mapper.Map<List<LookupDto>>(data);
            return Result<List<LookupDto>>.Success(mapData, "Country List");
        }
        /* public async Task<ActionResult<List<LookupDto>>> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
{
    var data = await _unitOfWork.Repositary<Country>().GetAll();
    if(data == null&& data.Count==0)
    {
        return Result<List<LookupDto>>.BadRequest("")
    }
    var mapdata=_mapper.Map<List<LookupDto>>(data);
    return Result<List<LookupDto>>.Success(mapdata, ("Countary List"));

}*/
    }
}
