using AutoMapper;
using SummitPro.Application.Repository;
using SummitPro.Core.Aggregate.Barbecue;
using SummitPro.Infrastructure.RepositoryInMemory.Models;

namespace SummitPro.Infrastructure.RepositoryInMemory
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

        public IEnumerable<Barbecue> GetAll()
        {
            if (_barbecues == null) return Enumerable.Empty<Barbecue>();

            var barbecues = _barbecues.FindAll(o => o.Identifier != Guid.Empty);

            if (!barbecues.Any()) return Enumerable.Empty<Barbecue>();

            var output = new List<Barbecue>();

            foreach (var barbecue in barbecues)
            {
                PreAssemblyAdditionalRemarks(barbecue);
                PreAssemblyParticipants(barbecue);
                output.Add(_mapper.Map<Barbecue>(barbecue));
            }

            return output;
        }

        public IEnumerable<Barbecue> GetByIdentifiers(IEnumerable<Guid> identifier)
        {
            List<BarbecueModel> models = _barbecues.FindAll(o => identifier.Contains(o.Identifier));
            var result = new List<Barbecue>();

            foreach (BarbecueModel model in models)
            {
                PreAssemblyAdditionalRemarks(model);
                PreAssemblyParticipants(model);
                result.Add(_mapper.Map<Barbecue>(model));
            }

            return result.AsEnumerable();
        }

        public void Update(Barbecue entity)
        {
            var model = _barbecues.FirstOrDefault(o => o.Identifier == entity.Identifier);

            if (model == null) return;

            var identifier = model.Identifier;

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

            if (!_additionalRemarks.Any() || !_additionalRemarks.ContainsKey(model.Identifier))
                return;

            IEnumerable<string> remarks = _additionalRemarks[model.Identifier];

            foreach (string remark in remarks)
            {
                if (model.AdditionalRemarks.Contains(remark)) continue;
                model.AdditionalRemarks.Add(remark);
            }
        }

        private void PreAssemblyParticipants(BarbecueModel model)
        {
            if (model == null) return;

            if (!_participants.Any() || !_participants.ContainsKey(model.Identifier)) return;

            IEnumerable<string> participants = _participants[model.Identifier];

            foreach (string participant in participants)
            {
                if (model.Participants.Contains(participant)) continue;
                model.Participants.Add(participant);
            }
        }
    }
}
