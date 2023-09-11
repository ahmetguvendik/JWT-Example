using System;
namespace Application.Services.Token
{
	public interface ITokenHandler
	{
		public DTOs.Token CreateAccessToken();
	}
}

