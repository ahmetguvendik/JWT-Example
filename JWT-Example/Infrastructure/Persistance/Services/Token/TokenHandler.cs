using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Application.Services.Token;
using Microsoft.IdentityModel.Tokens;

namespace Persistance.Services.Token
{
	public class TokenHandler : ITokenHandler
	{
        public Application.DTOs.Token CreateAccessToken()
        {
            var token = new Application.DTOs.Token();
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Bir berber bir berbere gel beraber bir berber dukkani acalim demis"));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            token.Expiration = DateTime.UtcNow.AddMinutes(1);
            JwtSecurityToken securityToken = new JwtSecurityToken(
                audience: "www.ahmet.com",
                issuer: "www.myapi.com",
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
                );
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = jwtSecurityTokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}

