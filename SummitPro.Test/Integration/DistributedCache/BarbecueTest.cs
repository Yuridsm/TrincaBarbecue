using AutoMapper;
using NUnit.Framework;
using SummitPro.Application.UseCase.CreateBarbecue;
using SummitPro.Core.Aggregate.Barbecue;
using SummitPro.Infrastructure.RepositoryInMemory.Models;
using SummitPro.SharedKernel.Interfaces;
using SummitPro.Application.UseCase.AddParticipante;
using SummitPro.Application.UseCase.BindParticipant;
using SummitPro.Infrastructure.DistributedCache;
using SummitPro.Infrastructure.RepositoryInMemory;

namespace SummitPro.Test.Integration.DistributedCache
{
    [TestFixture]
    public class BarbecueTest
    {
        private Mapper _mapper;
        private ICachedRepository _distributedCache = new CachedRepository();
        private ICollection<Guid> _identifiersToDeleteAfterTest = new List<Guid>();

        [SetUp]
        public void SetUp()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<ParticipantModelMapperProfile>();
                config.AddProfile<BarbecueModelMapperProfile>();
            });
            _mapper = new Mapper(mapperConfig);
        }

        [TearDown]
        public void TearDown()
        {
            ICachedRepository cache = new CachedRepository();

            foreach (var key in _identifiersToDeleteAfterTest)
            {
                cache.DeleteList<Barbecue>(key.ToString());
            }
        }

        [Test]
        public void ShouldCreateBarbecue()
        {
            // Arrange
            var barbecueRepository = new BarbecueRepositoryInMemory(_mapper);
            var distributedCache = new CachedRepository();

            var createBarbecue = new CreateBarbecueUseCase(barbecueRepository)
                .SetDistributedCache(distributedCache);

            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003",
            };

            var input = CreateInputBoundary.FactoryMethod("Description 01", additional, DateTime.Parse("26/05/2025 01:00:00 -3:00"), DateTime.Parse("26/05/2025 05:42:00 -3:00"));

            // Act
            var output = createBarbecue.Execute(input);

            // Assert
            Assert.IsNotNull(output);
            _identifiersToDeleteAfterTest.Add(Guid.Parse(output.GetIdentifier()));
        }

        [Test]
        public void ShouldAddParticipantsToBarbecue()
        {
            // Arrange
            var barbecueRepository = new BarbecueRepositoryInMemory(_mapper);
            var participantRepository = new ParticipantRepositoryInMemory(_mapper);
            var participantUseCase = new AddParticipantUseCase(barbecueRepository, participantRepository);
            var barbecueUseCase = new CreateBarbecueUseCase(barbecueRepository);
            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003",
            };

            var barbecueInput = CreateInputBoundary.FactoryMethod("Description 01", additional, DateTime.Parse("26/05/2025 01:00:00 -3:00"), DateTime.Parse("26/05/2025 05:42:00 -3:00"));
            var barbecueOutput = barbecueUseCase
                .SetDistributedCache(_distributedCache)
                .Execute(barbecueInput);

            var items = new List<string>
            {
                "Item 01",
                "Item 02",
                "Item 03"
            };

            var yuriParticipantInput = new AddParticipantInputBoundary("Yuri Melo", "@yuridsm", 200.00f, true, Guid.Parse(barbecueOutput.GetIdentifier()), items);
            var igorParticipantInput = new AddParticipantInputBoundary("Igor Melo", "@igordsm", 200.00f, true, Guid.Parse(barbecueOutput.GetIdentifier()), items);
            var iranParticipantInput = new AddParticipantInputBoundary("Iran Melo", "@irandsm", 200.00f, true, Guid.Parse(barbecueOutput.GetIdentifier()), items);

            // Act
            var yuriOutputParticipant = participantUseCase
                .SetDistributedCache(_distributedCache)
                .Execute(yuriParticipantInput);

            var igorOutputParticipant = participantUseCase
                .SetDistributedCache(_distributedCache)
                .Execute(igorParticipantInput);

            var iranOutputParticipant = participantUseCase
                .SetDistributedCache(_distributedCache)
                .Execute(iranParticipantInput);

            var yuriParticipant = participantRepository.Find(o => o.Identifier == yuriOutputParticipant.ParticipantIdentifier);
            var igorParticipant = participantRepository.Find(o => o.Identifier == igorOutputParticipant.ParticipantIdentifier);
            var iranParticipant = participantRepository.Find(o => o.Identifier == iranOutputParticipant.ParticipantIdentifier);

            // Assert
            Assert.That(yuriOutputParticipant.ParticipantIdentifier, Is.EqualTo(yuriParticipant.Identifier));
            Assert.That(igorOutputParticipant.ParticipantIdentifier, Is.EqualTo(igorParticipant.Identifier));
            Assert.That(iranOutputParticipant.ParticipantIdentifier, Is.EqualTo(iranParticipant.Identifier));

            _identifiersToDeleteAfterTest.Add(Guid.Parse(barbecueOutput.GetIdentifier()));
            _identifiersToDeleteAfterTest.Add(yuriOutputParticipant.ParticipantIdentifier);
            _identifiersToDeleteAfterTest.Add(igorOutputParticipant.ParticipantIdentifier);
            _identifiersToDeleteAfterTest.Add(iranOutputParticipant.ParticipantIdentifier);
        }

        [Test]
        public void ShouldBindParticipantsToBarbecue()
        {
            // Arrange
            var barbecueRepository = new BarbecueRepositoryInMemory(_mapper);
            var participantRepository = new ParticipantRepositoryInMemory(_mapper);
            var participantUseCase = new AddParticipantUseCase(barbecueRepository, participantRepository);
            var barbecueUseCase = new CreateBarbecueUseCase(barbecueRepository);
            var bindParticipant = new BindParticipantUseCase(barbecueRepository, participantRepository);

            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003",
            };

            var barbecueInput = CreateInputBoundary.FactoryMethod("Description 01", additional, DateTime.Parse("26/05/2025 01:00:00 -3:00"), DateTime.Parse("26/05/2025 05:42:00 -3:00"));
            var barbecueOutput = barbecueUseCase
                .SetDistributedCache(_distributedCache)
                .Execute(barbecueInput);

            var items = new List<string>
            {
                "Item 01",
                "Item 02",
                "Item 03"
            };

            var yuriParticipantInput = new AddParticipantInputBoundary("Yuri Melo", "@yuridsm", 200.00f, true, Guid.Parse(barbecueOutput.GetIdentifier()), items);
            var igorParticipantInput = new AddParticipantInputBoundary("Igor Melo", "@igordsm", 200.00f, true, Guid.Parse(barbecueOutput.GetIdentifier()), items);
            var iranParticipantInput = new AddParticipantInputBoundary("Iran Melo", "@irandsm", 200.00f, true, Guid.Parse(barbecueOutput.GetIdentifier()), items);

            // Act
            var yuriOutputParticipant = participantUseCase
                .SetDistributedCache(_distributedCache)
                .Execute(yuriParticipantInput);

            bindParticipant
                .SetDistributedCache(_distributedCache)
                .Execute(new BindParticipantInputBoundary
                {
                    BarbecueIdentifier = Guid.Parse(barbecueOutput.GetIdentifier()),
                    ParticipantIdentifier = yuriOutputParticipant.ParticipantIdentifier
                });

            var igorOutputParticipant = participantUseCase
                .SetDistributedCache(_distributedCache)
                .Execute(igorParticipantInput);

            var iranOutputParticipant = participantUseCase
                .SetDistributedCache(_distributedCache)
                .Execute(iranParticipantInput);

            var yuriParticipant = participantRepository.Find(o => o.Identifier == yuriOutputParticipant.ParticipantIdentifier);
            var igorParticipant = participantRepository.Find(o => o.Identifier == igorOutputParticipant.ParticipantIdentifier);
            var iranParticipant = participantRepository.Find(o => o.Identifier == iranOutputParticipant.ParticipantIdentifier);

            // Assert
            Assert.That(yuriOutputParticipant.ParticipantIdentifier, Is.EqualTo(yuriParticipant.Identifier));
            Assert.That(igorOutputParticipant.ParticipantIdentifier, Is.EqualTo(igorParticipant.Identifier));
            Assert.That(iranOutputParticipant.ParticipantIdentifier, Is.EqualTo(iranParticipant.Identifier));

            _identifiersToDeleteAfterTest.Add(Guid.Parse(barbecueOutput.GetIdentifier()));
            _identifiersToDeleteAfterTest.Add(yuriOutputParticipant.ParticipantIdentifier);
            _identifiersToDeleteAfterTest.Add(igorOutputParticipant.ParticipantIdentifier);
            _identifiersToDeleteAfterTest.Add(iranOutputParticipant.ParticipantIdentifier);
        }

    }
}
