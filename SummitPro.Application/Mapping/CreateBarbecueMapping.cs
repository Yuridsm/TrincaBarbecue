using AutoMapper;
using SummitPro.Application.CommandModel;
using SummitPro.Application.UseCase.CreateBarbecue;

//CreateMap<Barbecue, BarbecueModel>()
//                .ForMember(destination => destination.Identifier, map =>
//                {
//                    map.MapFrom(src => src.Identifier);
//                })
//                .ForMember(destination => destination.BeginDate, map =>
//                {
//                    map.MapFrom(src => src.BeginDate);
//                })
//                .ForMember(destination => destination.EndDate, map =>
//                {
//                    map.MapFrom(src => src.EndDate);
//                })
//                .ForMember(destination => destination.Participants, map =>
//                {
//                    map.MapFrom(src => src.Participants.ConvertAll(item => item.ToString()));
//                });

namespace SummitPro.Application.Mapping
{
    public class CreateBarbecueProfile : Profile
    {
        public CreateBarbecueProfile()
        {
            //CreateMap<CreateBarbecueInputBoundary, CreateBarbecueCommandModel>();
        }
    }
}
