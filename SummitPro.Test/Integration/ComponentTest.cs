using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SummitPro.Application.Command;
using SummitPro.Application.Command.Handler;
using SummitPro.Application.UseCase.CreateComponent;
using System.Reflection;

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

            var serviceProvider = services.BuildServiceProvider();
            _mediator = serviceProvider.GetRequiredService<IMediator>();
        }

        [Test]
        public async Task ShouldMediateCommandAndHandler()
        {
            // Arrange
            var input = new CreateComponentInputBoundary
            {
                Name = "Hydra Componente",
                Description = "Description of Component",
            };

            var useCase = new CreateComponentUseCase(_mediator);

            // Act
            Assert.DoesNotThrow(() => useCase.Execute(input));
        }
    }
}
