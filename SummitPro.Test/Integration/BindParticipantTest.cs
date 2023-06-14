using AutoMapper;
using NUnit.Framework;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

using SummitPro.Application;
using SummitPro.Application.Repository;
using SummitPro.Application.UseCase.CreateBarbecue;
using SummitPro.Application.UseCase.AddParticipante;
using SummitPro.Application.UseCase.BindParticipant;
using SummitPro.Application.DependencyInjection;
using SummitPro.Infrastructure;
using SummitPro.Infrastructure.RepositoryInMemory;
using SummitPro.Infrastructure.DependencyInjector;
using SummitPro.Application.Interface;

namespace SummitPro.Test.Integration
{
    [TestFixture]
    public class BindParticipantTest
    {
        private Mapper _mapper;
        private IMediator _mediator;
        private ServiceProvider _serviceProvider;

        [SetUp]
        public void SetUp()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IGateway<string>, Gateway>();
            services.AddSingleton<IBarbecueRepository, BarbecueRepositoryInMemory>();
            services.AddMediator();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddInfrastructureInMemory();
            services.AddUseCase();

            // Distributed Cache
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
                options.InstanceName = "redisinstance";
            });

            _serviceProvider = services.BuildServiceProvider();
            _mediator = _serviceProvider.GetRequiredService<IMediator>();
        }

        //[Test]
        //public async Task ShouldBindParticipanttoExistingBarbecue()
        //{
        //    // Arrange
        //    var barbecueUseCase = _serviceProvider.GetRequiredService<ICreateBarbecueUseCase>();
        //    var participantUseCase = _serviceProvider.GetRequiredService<IAddParticipantUseCase>();
        //    var bindParticipant = _serviceProvider.GetRequiredService<IBindParticipantUseCase>();

        //    var additional = new List<string>
        //    {
        //        "Description 001",
        //        "Description 002",
        //        "Description 003",

        //    };
        //    var barbecueInput = CreateInputBoundary.FactoryMethod("Description 01", additional, DateTime.Parse("26/05/2025 01:00:00 -3:00"), DateTime.Parse("26/05/2025 05:42:00 -3:00"));
        //    var barbecueOutput = await barbecueUseCase.Execute(barbecueInput);

        //    var items = new List<string>
        //    {
        //        "Item 01",
        //        "Item 02",
        //        "Item 03"
        //    };

        //    var participantInput = new AddParticipantInputBoundary("Yuri Melo", "@yuridsm", 100.00f, false, Guid.Parse(barbecueOutput.GetIdentifier()), items);

        //    var participantOutput = participantUseCase.Execute(participantInput);

        //    var bindParticipantInput = new BindParticipantInputBoundary
        //    {
        //        BarbecueIdentifier = Guid.Parse(barbecueOutput.GetIdentifier()),
        //        ParticipantIdentifier = participantOutput.ParticipantIdentifier
        //    };

        //    // Act
        //    bindParticipant.Execute(bindParticipantInput);

        //    var participant = barbecueRepository.Get(Guid.Parse(barbecueOutput.GetIdentifier()));

        //    // Assert
        //    Assert.IsNotNull(participant);
        //    Assert.Contains(participantOutput.ParticipantIdentifier, participant.Participants);
        //}
    }
}
