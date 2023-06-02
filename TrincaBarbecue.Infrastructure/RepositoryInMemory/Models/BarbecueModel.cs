using AutoMapper;
using TrincaBarbecue.Core.Aggregate.Barbecue;

namespace TrincaBarbecue.Infrastructure.RepositoryInMemory.Models
{
    public class BarbecueModel
    {
        public Guid Identifier { get; set; }
        public string Description { get; set; }
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
        public List<string> Participants { get; set; }
        public List<string> AdditionalRemarks { get; set; }
    }

    public class BarbecueModelMapperProfile : Profile
    {
        public BarbecueModelMapperProfile()
        {
            CreateMap<Barbecue, BarbecueModel>()
                .ForMember(destination => destination.Identifier, map =>
                {
                    map.MapFrom(src => src.Identifier);
                })
                .ForMember(destination => destination.BeginDate, map =>
                {
                    map.MapFrom(src => src.BeginDate);
                })
                .ForMember(destination => destination.EndDate, map =>
                {
                    map.MapFrom(src => src.EndDate);
                })
                .ForMember(destination => destination.Participants, map =>
                {
                    map.MapFrom(src => src.Participants.ConvertAll(item => item.ToString()));
                });

            CreateMap<BarbecueModel, Barbecue>()
                .ConstructUsing(src => Barbecue.FactoryMethod(
                        src.Description,
                        src.AdditionalRemarks,
                        DateTime.Parse(src.BeginDate),
                        DateTime.Parse(src.EndDate)
                    ));
        }
    }
}
