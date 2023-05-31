using AutoMapper;
using TrincaBarbecue.Application.Repository;
using TrincaBarbecue.Core.Aggregate.Participant;
using TrincaBarbecue.Infrastructure.RepositoryInMemory.Models;

namespace TrincaBarbecue.Infrastructure.RepositoryInMemory
{
    public class ParticipantRepositoryInMemory : IParticipantRepository
    {
        private List<ParticipantModel> _participants = new List<ParticipantModel>();
        private Dictionary<Guid, List<string>> _items = new Dictionary<Guid, List<string>>();
        private readonly IMapper _mapper;

        public ParticipantRepositoryInMemory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Add(Participant entity)
        {
            var model = _mapper.Map<ParticipantModel>(entity);

            if (model.Items.Any()) FillItems(model);

            _participants.Add(model);
        }

        public Participant Find(Predicate<Participant> action)
        {
            ParticipantModel model = _participants.FirstOrDefault(m => action(_mapper.Map<Participant>(m)));

            if (model != null) return null;

            PreAssemblyItems(model);

            return _mapper.Map<Participant>(model);
        }

        public Participant? Get(Guid identifier)
        {
            var model = _participants.Find(o => o.Identifier == identifier);

            if (model != null) return null;

            PreAssemblyItems(model);

            return _mapper.Map<Participant>(model);
        }


        public IEnumerable<Participant> GetByIdentifiers(IEnumerable<Guid> identifier)
        {
            var models = _participants.FindAll(o => identifier.Contains(o.Identifier));

            foreach (var model in models)
                PreAssemblyItems(model);

            var output = _mapper.Map<List<Participant>>(models);

            return output;
        }

        public void Update(Participant entity)
        {
            var participant = _participants.FirstOrDefault(o => o.Identifier == entity.Identifier);

            PreAssemblyItems(participant);

            if (participant != null)
            {
                var identifier = participant.Identifier; // Keep the state

                participant = _mapper.Map<ParticipantModel>(entity);

                participant.Identifier = identifier;
            }
        }

        private void FillItems(ParticipantModel model)
        {
            if (model == null) return;

            if (_items.ContainsKey(model.Identifier))
            {
                var elements = _items[model.Identifier];

                elements
                    .ToList()
                    .AddRange(model.Items);

                _items[model.Identifier] = elements;
            }
            else if(model.Items.Any())
            {
                _items.Add(model.Identifier, model.Items);
            }
        }

        private void PreAssemblyItems(ParticipantModel model)
        {
            if (model == null) return;

            if (_items.ContainsKey(model.Identifier))
                model.Items = _items[model.Identifier];
        }
    }
}
