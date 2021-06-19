using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using Timesheets.Infrastructupe.Validation;
using TimeSheets.Data;
using TimeSheets.Data.Implementation;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Implementation;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Infrastructure.Validation;
using TimeSheets.Models.Dto.Authentication;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Infrastructure
{
	internal static class ServiceCollectionExtensions
	{
		//База данных
		public static void ConfigureDbContext(this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddDbContext<TimeSheetDbContext>(options =>
			{
				options.UseNpgsql(
					configuration.GetConnectionString("DefaultConnection"),
					b => b.MigrationsAssembly("TimeSheets"));
			});
		}

		//Конфигурация swagger
		public static void ConfigureSwagger(this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "API сервиса учета рабочего времен ",
					Description = "Alexy Afanasev",					
				});				
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.Http,
					Scheme = "bearer",
					BearerFormat = "JWT"
				});
				c.AddSecurityRequirement(new OpenApiSecurityRequirement()
				{
					{
						new OpenApiSecurityScheme()
						{
							Reference = new OpenApiReference()
							{
								Type = ReferenceType.SecurityScheme, 
								Id = "Bearer"
							}
						},
						Array.Empty<string>()
					}
				});

				// Указываем файл из которого брать комментарии для Swagger UI
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				c.IncludeXmlComments(xmlPath, true);
				c.OrderActionsBy(apiDesc => apiDesc.RelativePath.Replace("/", "|"));
			});
		}

		//Обработчики данных
		public static void ConfigureDataHandlers(this IServiceCollection services,
			IConfiguration configuration)
		{
			// Репозитории
			services.AddScoped<IClientRepo, ClientRepo>();
			services.AddScoped<IContractRepo, ContractRepo>();
			services.AddScoped<IEmployeeRepo, EmployeeRepo>();
			services.AddScoped<IInvoiceRepo, InvoiceRepo>();
			services.AddScoped<IServiceRepo, ServiceRepo>();
			services.AddScoped<ISheetRepo, SheetRepo>();
			services.AddScoped<IUserRepo, UserRepo>();

			// Менеджеры работы с запросами
			services.AddScoped<IClientManager, ClientManager>();
			services.AddScoped<IContractManager, ContractManager>();
			services.AddScoped<IEmployeeManager, EmployeeManager>();
			services.AddScoped<IInvoiceManager, InvoiceManager>();
			services.AddScoped<IServiceManager, ServiceManager>();
			services.AddScoped<ISheetManager, SheetManager>();
			services.AddScoped<IUserManager, UserManager>();
		}

		//Аутнетификация
		public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<JwtAccessOptions>(configuration.GetSection("Authentication:JwtAccessOptions"));
			services.Configure<JwtRefreshOptions>(configuration.GetSection("Authentication:JwtRefreshOptions"));

			var jwtSettings = new JwtOptions();
			configuration.Bind("Authentication:JwtAccessOptions", jwtSettings);

			services.AddTransient<ILoginManager, LoginManager>();

			services
				.AddAuthentication(
					x =>
					{
						x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
						x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
					})
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = jwtSettings.GetTokenValidationParameters();
				});
		}

		public static void ConfigureValidtion(this IServiceCollection services)
		{
			services.AddTransient<IValidator<SheetRequest>, SheetRequestValidator>();
			services.AddTransient<IValidator<LoginRequest>, LoginRequestValidator>();
			services.AddTransient<IValidator<ClientRequest>, ClientRequestValidator>();
			services.AddTransient<IValidator<ContractRequest>, ContractRequestValidator>();
			services.AddTransient<IValidator<ContractUpdateRequest>, ContractUpdateRequestValidator>();
			services.AddTransient<IValidator<InvoiceRequest>, InvoiceRequestValidator>();
			services.AddTransient<IValidator<ServiceRequest>, ServiceRequestValidator>();
			services.AddTransient<IValidator<UserRequest>, UserRequestValidator>();
			services.AddTransient<IValidator<UserUpdateRequest>, UserUpdateRequestValidator>();

		}

	}
}