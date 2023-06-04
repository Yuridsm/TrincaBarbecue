using TrincaBarbecue.Application.UseCase.AddParticipante;
using TrincaBarbecue.Application.UseCase.BindParticipant;
using TrincaBarbecue.Application.UseCase.CreateBarbecue;
using TrincaBarbecue.Application.UseCase.GetByIdBarbecue;
using TrincaBarbecue.Application.UseCase.GetParticipant;
using TrincaBarbecue.Infrastructure.Http.Controller;
using TrincaBarbecue.Infrastructure.DependencyInjector;

namespace TrincaBarbecue.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddInfrastructureInMemory();

            services.AddSingleton<CreateBarbecueUseCase>();
            services.AddSingleton<AddParticipantUseCase>();
            services.AddSingleton<BindParticipantUseCase>();
            services.AddSingleton<GetBarbecueByIdUseCase>();
            services.AddSingleton<GetParticipantsUseCase>();

            services.AddTransient<CreateBarbecueController>();
            services.AddTransient<AddParticipantController>();
            services.AddTransient<BindParticipantTobarbecueController>();
            services.AddTransient<GetbarbecueByIdController>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            // Outras configurações...

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
