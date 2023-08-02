using MediatR;
using StajProjesiAPI.Application.Abstract.Services;
using StajProjesiAPI.Application.Contacts;
using StajProjesiAPI.Application.Utilities.Result;

namespace StajProjesiAPI.Application.Features.Commands.Documents
{
    public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommandRequest, CreateDocumentCommandResponse>
    {
        private readonly IDocumentService _documentService;

        public CreateDocumentCommandHandler(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public async Task<CreateDocumentCommandResponse> Handle(CreateDocumentCommandRequest request, CancellationToken cancellationToken)
        {
            byte[] fileData = Convert.FromBase64String(request.file);
            var createDocument =  await _documentService.AddUploadAsync(fileData, "/file/product");
            if (createDocument != null)
            {
                return new CreateDocumentCommandResponse { FileCode = createDocument };
            }
            else 
            {
                return new CreateDocumentCommandResponse { FileCode = null };
                
            };

        }
    }
}
