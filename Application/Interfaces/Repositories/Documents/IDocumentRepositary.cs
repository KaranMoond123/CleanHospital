using Domain.Entities.Dcouments;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.Documents
{
   public interface IDocumentRepositary
    {
        Task<Dcoument> Create(IFormFile form, string? name = null);
    }
}
