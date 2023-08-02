using AutoMapper;
using MediatR;
using StajProjesiAPI.Application.Abstract.Services;
using StajProjesiAPI.Application.Contacts;
using StajProjesiAPI.Application.Dtos.AppUser;
using StajProjesiAPI.Application.Features.Queries;
using StajProjesiAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Features.Commands
{
    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommandRequest, UpdateAppUserCommandResponse>
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateAppUserCommandHandler(IAppUserService appUserService, IMapper mapper, IMediator mediator)
        {
            _appUserService = appUserService;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<UpdateAppUserCommandResponse> Handle(UpdateAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            var authenticatedUserQuery = new GetAuthenticatedUserQueryRequest();
            var authenticatedUserResponse = await _mediator.Send(authenticatedUserQuery);//sisteme authenticate olan kullancıyı getir
            if (authenticatedUserResponse != null) 
            {
               var authenticatedUser = authenticatedUserResponse.AppUser;
                var mappedUser = _mapper.Map<UpdateAppUserDto, AppUser>(request.UpdateAppUserDto,authenticatedUser);
                var userEmailControlQuery = new GetAppUserByEmailQueryRequest() { Email = mappedUser.Email };
                var userEmailControl = await _mediator.Send(userEmailControlQuery);

                if (userEmailControl.AppUser == null) // mail kullanımda mı kontrolü
                {
                    authenticatedUser.UserName = mappedUser.UserName;
                    authenticatedUser.PhoneNumber = mappedUser.PhoneNumber;
                    authenticatedUser.FirstName = mappedUser.FirstName;
                    authenticatedUser.LastName = mappedUser.LastName;
                    authenticatedUser.Email = mappedUser.Email;
                }
                else { return new UpdateAppUserCommandResponse { Message = Messages.UserAlreadyExists }; }
               

                try
                {
                    var UpdatedUser = await _appUserService.UpdateAsync(mappedUser);
                    if(UpdatedUser.Success)
                    {
                        return new UpdateAppUserCommandResponse { Message = Messages.UpdateMessage };
                    }
                }
                catch (Exception ex) { return new UpdateAppUserCommandResponse { Message= Messages.ErrorMessage }; }


            }
            return new UpdateAppUserCommandResponse { Message = Messages.UserNotFound };



        }
    }
}
