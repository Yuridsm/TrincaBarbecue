using System.Text.Json;
using SummitPro.Application.DependencyInjection;
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
            services.AddControllers()
            .AddJsonOptions(options => {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddInfrastructureInMemory();

            services.AddSingleton<CreateBarbecueUseCase>();
            services.AddSingleton<AddParticipantUseCase>();
            services.AddSingleton<BindParticipantUseCase>();
            services.AddSingleton<GetBarbecueByIdUseCase>();

            services.AddTransient<CreateBarbecueController>();
            services.AddTransient<BindParticipantTobarbecueController>();

            services.AddMediator();
            services.AddUseCase();
            services.AddLog();
            services.AddApplicationService();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddRazorPages();

            services.AddCors(options => {
                options.AddPolicy("BarbecueOrigins", policy => {
                    policy.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("BarbecueOrigins");

            app.UseStaticFiles();

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
