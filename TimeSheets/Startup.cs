using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TimeSheets.Infrastructure;

namespace TimeSheets
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }
		public void ConfigureServices(IServiceCollection services)
		{
			// Контроллеры
			services.AddControllers();

			// Swagger
			services.ConfigureSwagger(Configuration);

			// Обработчики данных (менеджеры и репозитории)
			services.ConfigureDataHandlers(Configuration);

			// Контекст базы данных
			services.ConfigureDbContext(Configuration);

			// Аутентификация
			services.ConfigureAuthentication(Configuration);

			// Валидация
			services.ConfigureValidtion();
			services.AddControllers()
				.AddFluentValidation();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "API сервиса учета рабочего времени");
				c.RoutePrefix = string.Empty;
			});

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

		}
	}
}
