using System.Reflection;
using Api.Application.Fincas.Create;
using Api.Domain.Abstractions;
using Api.Infraestructure;
using Api.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//application
builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});

//infrastrucuture
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<ApplicationDbContext>( options => {
    options.UseSqlServer(connectionString).UseLowerCaseNamingConvention();
});
builder.Services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
