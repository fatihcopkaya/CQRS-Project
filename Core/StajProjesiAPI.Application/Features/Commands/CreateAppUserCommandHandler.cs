using AutoMapper;
using MediatR;
using StajProjesiAPI.Application.Abstract.Services;
using StajProjesiAPI.Application.Dtos.AppUser;
using StajProjesiAPI.Application.Features.Queries;
using StajProjesiAPI.Domain.Entities;

namespace StajProjesiAPI.Application.Features.Commands
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommandRequest, CreateAppUserCommandResponse>
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IHashingHelperService _hashingHelperService;
        private readonly JWTTokenService _jwtTokenService;

        public CreateAppUserCommandHandler(IAppUserService appUserService, IMapper mapper, IMediator mediator, IHashingHelperService hashingHelperService, JWTTokenService jwtTokenService)
        {
            _appUserService = appUserService;
            _mapper = mapper;
            _mediator = mediator;
            _hashingHelperService = hashingHelperService;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<CreateAppUserCommandResponse> Handle(CreateAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {

                var QueryAppUser = new GetAppUserByEmailQueryRequest() { Email = request.CreateAppUserDTO.Email };
                var QueryAppUserResponse = await _mediator.Send(QueryAppUser);
                if (QueryAppUserResponse.AppUser != null)
                {
                    return new CreateAppUserCommandResponse { IsSuccess = false }; //Email kullanımda
                }

                var appUserDto = request.CreateAppUserDTO;
                _hashingHelperService.CreatePasswordHash(appUserDto.Password, out var passwordHash, out var passwordSalt);
                var _mappedAppUser = _mapper.Map<CreateAppUserDto, AppUser>(appUserDto);
                _mappedAppUser.PasswordHash = passwordHash;
                _mappedAppUser.PasswordSalt = passwordSalt;
                _mappedAppUser.CreatedDate = DateTime.UtcNow;
                _mappedAppUser.IsActive = true;
                var CreatedAppUser = await _appUserService.AddAsync(_mappedAppUser);
                var tokenVM = _jwtTokenService.GetToken(_mappedAppUser.Email, _mappedAppUser.Role);
                CreatedAppUser.Data.RefreshToken = tokenVM.RefreshToken;
                CreatedAppUser.Data.RefreshTokenEndDate = tokenVM.RefreshTokenEndDate;
                CreatedAppUser.Data.IsActive = true;
                await _appUserService.UpdateAsync(CreatedAppUser.Data);
                return new CreateAppUserCommandResponse { IsSuccess = true };

            }
            catch (Exception ex)
            {
                return new CreateAppUserCommandResponse { IsSuccess = false };



            }

        }
    }
}
