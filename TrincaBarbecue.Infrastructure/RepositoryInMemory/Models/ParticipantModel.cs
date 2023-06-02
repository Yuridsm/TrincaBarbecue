using AutoMapper;
using TrincaBarbecue.Core.Aggregate.Participant;

namespace TrincaBarbecue.Infrastructure.RepositoryInMemory.Models
{
    public class ParticipantModel
    {
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public double ContributionValue { get; set; }
        public string BringDrink { get; set; }
        public List<string> Items { get; set; }
        public string Username { get; set; }
    }

    public class ParticipantModelMapperProfile : Profile
    {
        public ParticipantModelMapperProfile()
        {
            CreateMap<Participant, ParticipantModel>()
                .ForMember(destination => destination.Name, map =>
                {
                    map.MapFrom(src => src.Name.Value);
                })
                .ForMember(destination => destination.ContributionValue, map =>
                {
                    map.MapFrom(src => src.ContributionValue.Value);
                })
                .ForMember(destination => destination.BringDrink, map =>
                {
                    map.MapFrom(src => src.BringDrink.ToString());
                })
                .ForMember(destination => destination.Username, map =>
                {
                    map.MapFrom(src => src.Username.Value);
                })
                .ForMember(destination => destination.Items, map =>
                {
                    map.MapFrom(src => src.Items);
                });

            CreateMap<ParticipantModel, Participant>()
                .ConstructUsing(src => Participant.FactoryMethod(
                    src.Name,
                    src.Username,
                    src.ContributionValue,
                    src.BringDrink == "True" ? true : false)
                .AddItems(src.Items));
        }
    }
}
