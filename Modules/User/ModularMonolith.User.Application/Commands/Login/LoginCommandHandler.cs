using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ModularMonolith.User.Application.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IJwtService _jwtService;

        public LoginCommandHandler(UserManager<IdentityUser> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            
            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return string.Empty;
            }

            return _jwtService.GenerateJwt(new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
            });
        }
    }
}