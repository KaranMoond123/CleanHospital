using Application.Dto.Loopup;
using Application.Interfaces.UnitOfWorkRepositories;
using AutoMapper;
using Domain.Entities.Countries;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Countries.Queries.GetCountrybyId
{
    public class GetCountryByIdquary:IRequest<Result<LookupDto>>
    {
        public int Id { get; set; }
        public GetCountryByIdquary(int id)
        {
            Id = id;
        }
        internal class GetCounatryByIdHandler : IRequestHandler<GetCountryByIdquary,Result<LookupDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetCounatryByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<LookupDto>> Handle(GetCountryByIdquary request, CancellationToken cancellationToken)
            {
                var data=await _unitOfWork.Repositary<Country>().GetByID(request.Id);
                if(data==null)
                {
                    return Result<LookupDto>.BadRequest($"Sorry Id{request.Id} not Found");
                }
                var mapdata=_mapper.Map<LookupDto>(data);
                return Result<LookupDto>.Success(mapdata, "Country Data");
            }
        }
    }
}
