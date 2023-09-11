using System;
using Application.Services.Token;
using Persistance.Services.Token;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistance.Contexts;

namespace Persistance
{
	public static class ServiceRegistration
	{
        public static void AddPersistanceService(this IServiceCollection services)
        {
            services.AddDbContext<ProjectDbContext>(opt => opt.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=JWTDb;"));
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ProjectDbContext>();
            services.AddScoped<ITokenHandler, Persistance.Services.Token.TokenHandler>();

        }
	}
}

