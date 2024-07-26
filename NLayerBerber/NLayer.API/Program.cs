using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLayer.API.Filters;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository;
using NLayer.Repository.Repositories;
using NLayer.Repository.UnitOfWorks;
using NLayer.Service.Mappping;
using NLayer.Service.Services;
using NLayer.Service.Validations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/*
builder.Services.AddControllers(options => options.Filters.Add(new ValidatorFilterAttribute())).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<RezervasyonDtoVlidator>());

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
options.SuppressModelStateInvalidFilter = true;
});

*/

builder.Services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<RezervasyonDtoVlidator>());



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opts =>
{
	// Ýzin verilen domainler, portlar
	//opts.AddPolicy("AllowSites", pol =>
	//{
	//    pol.WithOrigins("https://localhost:5002", "https://www.domain.com", "https://domain.com").AllowAnyHeader().AllowAnyMethod();
	//});

	// Þimdilik tüm eriþime izin veriyoruz. Proje bitince üstteki gibi filtrelemeye girilebilir.
	opts.AddDefaultPolicy(pol =>
	{
		pol.WithOrigins("http://localhost:5173", "http://localhost:5174").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
	});
});

builder.Services.AddScoped<IUnitOfWorks, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<AppDbContext>(x =>
{
	x.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"), option =>
	{
		option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
	});

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
