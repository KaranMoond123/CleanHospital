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

namespace Application.Features.Countries.Commands.DeletedCountries
{
    public class DeleteCountryCommand:IRequest<Result<int>>
    {
        public int Id { get; set; }
        public DeleteCountryCommand(int id)
        {
            Id = id;
        }

    }
    internal class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCountryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var data=await _unitOfWork.Repositary<Country>().GetByID(request.Id);
            if(data == null) 
            {
                return Result<int>.BadRequest($"Sorry Delete Id={request.Id} not Found");
            }
            var mapdata=_mapper.Map<Country>(data);
            await _unitOfWork.Repositary<Country>().DeleteAsync(mapdata);
            await _unitOfWork.Save(cancellationToken);
            return Result<int>.Success($"Data Deleted......");
        }
    }
}
