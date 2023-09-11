using System;
using MediatR;

namespace Application.CQRS.Commands.User.LoginUser
{
	public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
	{
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

