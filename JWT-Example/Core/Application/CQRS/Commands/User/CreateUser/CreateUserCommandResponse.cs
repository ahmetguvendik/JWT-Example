using System;
namespace Application.CQRS.Commands.User.CreateUser
{
	public class CreateUserCommandResponse
	{
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

