using MediatR;


namespace StajProjesiAPI.Application.Features.Commands.Documents
{
    public class CreateDocumentCommandRequest : IRequest<CreateDocumentCommandResponse>
    {
        public string file { get; set; }
       
    }
}
