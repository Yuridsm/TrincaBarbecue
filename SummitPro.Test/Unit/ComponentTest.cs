using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SummitPro.Application.Command;
using SummitPro.Application.Handler;
using System.Reflection;

namespace SummitPro.Test.Unit
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
            var component = new CreateComponentCommand
            {
                Name = "My Custom Component",
                Description = "Description"
            };

            var componentId = await _mediator.Send(component);

            // Act & Assert
            Assert.That(componentId, Is.InstanceOf<Guid>());
        }
    }
}
