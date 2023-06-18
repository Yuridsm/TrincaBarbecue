using SummitPro.Application.UseCase.AddParticipante;
using SummitPro.Application.UseCase.BindParticipant;
using SummitPro.Application.UseCase.CreateBarbecue;
using SummitPro.Application.UseCase.GetBarbecueById;
using SummitPro.Infrastructure.DependencyInjector;
using SummitPro.Infrastructure.Http.Controller;

namespace SummitPro.Web
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
            //services.AddSingleton<GetParticipantsUseCase>();

            services.AddTransient<CreateBarbecueController>();
            //services.AddTransient<AddParticipantController>();
            services.AddTransient<BindParticipantTobarbecueController>();
            //services.AddTransient<GetbarbecueByIdController>();

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
