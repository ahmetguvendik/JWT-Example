using System;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Contexts
{
	public class ProjectDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
		public ProjectDbContext(DbContextOptions options) : base(options) { }

    }
}

