using System;
using MediatR;

namespace Application.CQRS.Commands.User.CreateUser
{
	public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
	{
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

