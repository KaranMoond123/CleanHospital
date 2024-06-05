using Application.Interfaces.UnitOfWorkRepositories;
using AutoMapper;
using Domain.Entities.Countries;
using MediatR;
using Shared;

namespace Application.Features.Countries.Commands.CreateCountries
{
    public class CreateCountryCommand:IRequest<Result<int>>
    {  
        public string Name {  get; set; }
    }
    internal class CreateCountryCommmandHandler : IRequestHandler<CreateCountryCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateCountryCommmandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var mapData = _mapper.Map<Country>(request);

            await _unitOfWork.Repositary<Country>().AddAsync(mapData);
            await _unitOfWork.Save(cancellationToken);
           return Result<int>.Success("Inserted......");
        }
    }

}
