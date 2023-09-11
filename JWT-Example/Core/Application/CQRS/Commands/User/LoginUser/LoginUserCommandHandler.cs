using System;
using Application.DTOs;
using Application.Services.Token;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.CQRS.Commands.User.LoginUser
{
	public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest,LoginUserCommandResponse>
	{
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        public LoginUserCommandHandler(SignInManager<AppUser> signInManager,UserManager<AppUser> userManager,ITokenHandler tokenHandler)
		{
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenHandler = tokenHandler;
		}

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken();
                return new LoginUserCommandResponse()
                {
                    Token = token,
                    Message = "Token Olusturuldu"
                };

            }

            return new LoginUserCommandResponse()
            {
                Message = "HATA"
            };
           
        }
    }
}

