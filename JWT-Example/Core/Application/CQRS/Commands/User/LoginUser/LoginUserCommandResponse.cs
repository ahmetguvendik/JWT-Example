using System;
using Application.DTOs;

namespace Application.CQRS.Commands.User.LoginUser
{
	public class LoginUserCommandResponse
	{
		public Token Token { get; set; }
		public string Message { get; set; }	
	}
}

