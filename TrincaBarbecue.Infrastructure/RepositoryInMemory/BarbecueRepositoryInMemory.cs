using AutoMapper;
using TrincaBarbecue.Application.Repository;
using TrincaBarbecue.Core.Aggregate.Barbecue;
using TrincaBarbecue.Infrastructure.RepositoryInMemory.Models;

namespace TrincaBarbecue.Infrastructure.RepositoryInMemory
{
    public class BarbecueRepositoryInMemory : IBarbecueRepository
    {
        private readonly IMapper _mapper;

        // It seems like Collection or Table in Relational Database
        private List<BarbecueModel> _barbecues = new List<BarbecueModel>();
        private Dictionary<Guid, IEnumerable<string>> _additionalRemarks = new Dictionary<Guid, IEnumerable<string>>();
        private Dictionary<Guid, IEnumerable<string>> _participants = new Dictionary<Guid, IEnumerable<string>>();

        public BarbecueRepositoryInMemory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Add(Barbecue entity)
        {
            var model = _mapper.Map<BarbecueModel>(entity);

            FillAdditionalRemarks(model);
            FillParticipants(model);

            _barbecues.Add(model);
        }

        public Barbecue Find(Predicate<Barbecue> action)
        {
            BarbecueModel model = _barbecues.FirstOrDefault(m => action(_mapper.Map<Barbecue>(m)));

            return _mapper.Map<Barbecue>(model);
        }

        public Barbecue? Get(Guid identifier)
        {
            var model = _barbecues.Find(o => o.Identifier == identifier);

            return _mapper.Map<Barbecue>(model);
        }

        public void Update(Barbecue entity)
        {
            var model = _barbecues.FirstOrDefault(o => o.Identifier == entity.Identifier);

            if (model == null) return;

            var identifier = model.Identifier; // Keep the state

            model = _mapper.Map<BarbecueModel>(entity);

            FillAdditionalRemarks(model);
            FillParticipants(model);

            model.Identifier = identifier;

            _barbecues.RemoveAll(o => o.Identifier == identifier);
            _barbecues.Add(model);
        }

        private void FillAdditionalRemarks(BarbecueModel model)
        {
            if (model == null) return;

            if (_additionalRemarks.ContainsKey(model.Identifier))
            {
                var elements = _additionalRemarks[model.Identifier];

                elements = model.AdditionalRemarks;

                _additionalRemarks[model.Identifier] = elements;
            }
            else if (model.AdditionalRemarks.Any())
            {
                _additionalRemarks.Add(model.Identifier, model.AdditionalRemarks);
            }
        }

        private void FillParticipants(BarbecueModel model)
        {
            if (model == null) return;

            if (_participants.ContainsKey(model.Identifier))
            {
                var elements = _participants[model.Identifier];

                elements
                    .ToList()
                    .AddRange(model.Participants);

                _participants[model.Identifier] = elements;
            } 
            else if (model.Participants.Any())
            {
                _participants.Add(model.Identifier, model.Participants);
            }
        }

        private void PreAssemblyAdditionalRemarks(BarbecueModel model)
        {
            if (model == null) return;

            if (_additionalRemarks.Any() && _additionalRemarks.ContainsKey(model.Identifier))
                foreach (KeyValuePair<Guid, IEnumerable<string>> remark in _additionalRemarks)
                    model.AdditionalRemarks.Add(remark.Value.ToString());
        }

        private void PreAssemblyParticipants(BarbecueModel model)
        {
            if (model == null) return;

            if (_participants.Any() && _participants.ContainsKey(model.Identifier))
                foreach (KeyValuePair<Guid, IEnumerable<string>> participant in _participants)
                    model.Participants.Add(participant.Value.ToString());
        }
    }
}
