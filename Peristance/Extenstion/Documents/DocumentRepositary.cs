using Application.Interfaces.Repositories.Documents;
using Application.Interfaces.UnitOfWorkRepositories;
using Domain.Entities.Dcouments;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Peristance.Extenstion.Documents
{
    public class DocumentRepositary : IDocumentRepositary
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        private CancellationToken cancellationToken;
        private const string ImageUrl = "https://localhost:7060/Document";

        public DocumentRepositary(IWebHostEnvironment webHostEnvironment, IUnitOfWork unitOfWork)
        {
            _webHostEnvironment = webHostEnvironment;
            _unitOfWork = unitOfWork;
        }

        public async Task<Dcoument> Create(IFormFile form, string? name = null)
        {
            var fileExtension = Path.GetExtension(form.FileName).ToLower();
            var filename = $"{Guid.NewGuid():N}{fileExtension}";
            var filepath = Path.Combine(_webHostEnvironment.WebRootPath, "Document", filename);
            using (var filestream = new FileStream(filepath, FileMode.Create))
            {
                await form.CopyToAsync(filestream);
            }
            var document = new Dcoument
            {
                Name = name ?? filename,
                Url = $"{ImageUrl}/{filename}"
            };
            await _unitOfWork.Repositary<Dcoument>().AddAsync(document);
            await _unitOfWork.Save(cancellationToken);
            return document;
        }
    }
}
