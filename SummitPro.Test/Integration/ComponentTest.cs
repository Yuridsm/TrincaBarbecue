using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Reflection;

using SummitPro.Application;
using SummitPro.Application.Command.Handler;
using SummitPro.Application.UseCase.CreateComponent;
using SummitPro.Infrastructure;

namespace SummitPro.Test.Integration
{
    public class ComponentTest
    {
        private IMediator _mediator;

        [SetUp]
        public void SetUp()
        {
            var services = new ServiceCollection();
            var assembly = Assembly.GetAssembly(typeof(CreateComponentHandler));
            services.AddMediatR(o => o.RegisterServicesFromAssembly(assembly));

            services.AddSingleton<IGateway<string>, Gateway>();

            var serviceProvider = services.BuildServiceProvider();
            _mediator = serviceProvider.GetRequiredService<IMediator>();
        }

        [Test]
        public async Task ShouldMediateCommandAndHandler()
        {
            // Arrange
            var input01 = new CreateComponentInputBoundary
            {
                Name = "Hydra Componente",
                Description = "Description of Hydra Component",
            };

            var input02 = new CreateComponentInputBoundary
            {
                Name = "007 Componente",
                Description = "Description of 007 Component",
            };

            var input03 = new CreateComponentInputBoundary
            {
                Name = "Pimenta Componente",
                Description = "Description of Pimenta Component",
            };

            var useCase = new CreateComponentUseCase(_mediator);

            // Act
            var output01 = await useCase.Execute(input01);
            var output02 = await useCase.Execute(input02);
            var output03 = await useCase.Execute(input03);

            // Assert
            Assert.IsNotNull(output01);
            Assert.That(input01.Name, Is.EqualTo(output01.Name));
            Assert.That(input01.Description, Is.EqualTo(output01.Description));

            Assert.IsNotNull(output02);
            Assert.That(input02.Name, Is.EqualTo(output02.Name));
            Assert.That(input02.Description, Is.EqualTo(output02.Description));

            Assert.IsNotNull(output03);
            Assert.That(input03.Name, Is.EqualTo(output03.Name));
            Assert.That(input03.Description, Is.EqualTo(output03.Description));
        }
    }
}
