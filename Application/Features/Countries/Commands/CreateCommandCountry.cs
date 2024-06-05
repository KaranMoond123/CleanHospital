using Application.Features.Countries.Commands.CreateCountries;
using Application.Interfaces.UnitOfWorkRepositories;
using AutoMapper;
using Domain.Entities.Countries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Countries.Commands
{
    public class CreateCommandCountry:IRequest<Result<int>>
    {
        public string Name {  get; set; }   
    }
    internal class CreateCommandCountryHAndler : IRequestHandler<CreateCommandCountry, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateCommandCountryHAndler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(CreateCommandCountry request, CancellationToken cancellationToken)
        {
            var mapData = _mapper.Map<Country>(request);
            await _unitOfWork.Repositary<Country>().AddAsync(mapData);
            await _unitOfWork.Save(cancellationToken);
            return Result<int>.Success("Inserted......");
        }
    }

}
