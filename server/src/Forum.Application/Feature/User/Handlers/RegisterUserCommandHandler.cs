using Forum.Application.Contracts.Infrastructure;
using Forum.Application.Contracts.Persistence;
using Forum.Application.Feature.User.Requests;
using Forum.Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Forum.Application.Feature.User.Handlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IJwtTokenService _jwtTokenService;

    public RegisterUserCommandHandler(IUserRepository userRepository, IUserRoleRepository userRoleRepository, IJwtTokenService jwtTokenService)
    {
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
        _jwtTokenService = jwtTokenService;
    }
    
    public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if(await _userRepository.EmailExistsAsync(request.Email) || await _userRepository.UsernameExistsAsync(request.Username)) 
            throw new ApplicationException("This email is already registered");

        var role = await _userRoleRepository.GetByNameAsync("user");

        var user = new Domain.Entities.User.User
        {
            Credentials = new UserCredentials
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = null!
            },
            Profile = new UserProfile(),
            Roles = new List<UserRole> { role! }
        };
        
        user.Credentials.PasswordHash = new PasswordHasher<Domain.Entities.User.User>()
            .HashPassword(user, request.Password);
        
        user = await _userRepository.AddAsync(user);
        
        return _jwtTokenService.GenerateToken(user);
    }
}