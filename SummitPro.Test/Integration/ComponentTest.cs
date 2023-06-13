using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

using SummitPro.Application;
using SummitPro.Infrastructure;
using SummitPro.Application.DependencyInjection;

namespace SummitPro.Test.Integration
{
    public class ComponentTest
    {
        private IMediator _mediator;

        [SetUp]
        public void SetUp()
        {
            var services = new ServiceCollection();
            services.AddMediator();

            services.AddSingleton<IGateway<string>, Gateway>();

            var serviceProvider = services.BuildServiceProvider();
            _mediator = serviceProvider.GetRequiredService<IMediator>();
        }

        //[Test]
        //public async Task ShouldMediateCommandAndHandler()
        //{
        //    // Arrange
        //    var input01 = new CreateComponentInputBoundary
        //    {
        //        Name = "Hydra Componente",
        //        Description = "Description of Hydra Component",
        //    };

        //    var useCase = new CreateComponentUseCase(_mediator);

        //    // Act
        //    var output01 = await useCase.Execute(input01);

        //    // Assert
        //    Assert.IsNotNull(output01);
        //    Assert.That(input01.Name, Is.EqualTo(output01.Name));
        //    Assert.That(input01.Description, Is.EqualTo(output01.Description));
        //}
    }
}
