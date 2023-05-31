using TrincaBarbecue.Application.Repository;
using TrincaBarbecue.Application.UseCase.AddParticipante;
using TrincaBarbecue.Application.UseCase.BindParticipant;
using TrincaBarbecue.Application.UseCase.CreateBarbecue;
using TrincaBarbecue.Application.UseCase.GetByIdBarbecue;
using TrincaBarbecue.Infrastructure.Http.Controller;
using TrincaBarbecue.Infrastructure.RepositoryInMemory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IBarbecueRepository, BarbecueRepositoryInMemory>();
builder.Services.AddSingleton<IParticipantRepository, ParticipantRepositoryInMemory>();

builder.Services.AddScoped<CreateBarbecueUseCase>();
builder.Services.AddScoped<AddParticipantUseCase>();
builder.Services.AddScoped<BindParticipantUseCase>();
builder.Services.AddScoped<GetBarbecueByIdUseCase>();

builder.Services.AddScoped<CreateBarbecueController>();
builder.Services.AddScoped<AddParticipantController>();
builder.Services.AddScoped<BindParticipantTobarbecueController>();
builder.Services.AddScoped<GetbarbecueByIdController>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
