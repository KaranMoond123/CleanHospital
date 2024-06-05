using Application.Dto.Cities;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Queries.GetAllCities
{
    public class GetCityQuery:IRequest<Result<List<GetCityDto>>>
    {
    }
    internal class GetCityQueryHandler : IRequestHandler<GetCityQuery, Result<List<GetCityDto>>>
    {
        public Task<Result<List<GetCityDto>>> Handle(GetCityQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
