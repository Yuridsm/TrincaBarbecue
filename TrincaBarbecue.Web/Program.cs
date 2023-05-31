using TrincaBarbecue.Application.Repository;
using TrincaBarbecue.Application.UseCase.CreateBarbecue;
using TrincaBarbecue.Web.Controllers;
using TrincaBarbecue.Infrastructure.RepositoryInMemory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBarbecueRepository, BarbecueRepositoryInMemory>();
builder.Services.AddScoped<CreateBarbecueUseCase>();
builder.Services.AddScoped<CreateBarbecueController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.MapControllers();

app.Run();
