using System;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.CQRS.Commands.User.CreateUser
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest,CreateUserCommandResponse>
	{
        private readonly UserManager<AppUser> _userManager;
        public CreateUserCommandHandler(UserManager<AppUser> userManager)
		{
            _userManager = userManager;
		}

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = new AppUser();
            user.Id = Guid.NewGuid().ToString();
            user.UserName = request.UserName;
            var response = await _userManager.CreateAsync(user, request.Password);
            if (response.Succeeded)
            {
                return new CreateUserCommandResponse()
                {
                    UserName = request.UserName,
                    Password = request.Password
                };
            }

            return new CreateUserCommandResponse();
        }
    }
}

