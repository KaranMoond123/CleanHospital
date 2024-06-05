using Application.Interfaces.Repositories.Documents;
using MediatR;
using Microsoft.AspNetCore.Http;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Dcouments.Commands.CreateDocuments
{
    public class CreateDcoumentCommand:IRequest<Result<int>>
    {
        public string Name {  get; set; }
        public IFormFile Url { get; set; }
    }
    internal class CreateDcoumentCommandHandler : IRequestHandler<CreateDcoumentCommand, Result<int>>
    {
        private readonly IDocumentRepositary _documentRepositary;

        public CreateDcoumentCommandHandler(IDocumentRepositary documentRepositary)
        {
            _documentRepositary = documentRepositary;
        }

        public async Task<Result<int>> Handle(CreateDcoumentCommand request, CancellationToken cancellationToken)
        {
           var data=await _documentRepositary.Create(request.Url, request.Name);
            if(data == null)
            {
                return Result<int>.BadRequest("Invalid Request.....");
            }
            return Result<int>.Success(data.Id,"Created SuccessFully.....");
        }
    }
}
