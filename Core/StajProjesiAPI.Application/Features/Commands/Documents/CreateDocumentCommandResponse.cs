using MediatR;
using StajProjesiAPI.Application.Utilities.Result;
using StajProjesiAPI.Domain.Entities;


namespace StajProjesiAPI.Application.Features.Commands.Documents
{
    public class CreateDocumentCommandResponse : IRequest<CreateDocumentCommandRequest>
    {
        public string FileCode { get; set; }
    }
}
