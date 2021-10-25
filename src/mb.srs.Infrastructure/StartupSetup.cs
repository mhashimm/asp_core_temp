using mb.srs.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace mb.srs.Infrastructure
{
	public static class StartupSetup
	{
		public static void AddDbContext(this IServiceCollection services, string connectionString) =>
			services.AddDbContext<AppDbContext>(options =>
				options.UseSqlite(connectionString)); // will be created in web project root
	}
}
