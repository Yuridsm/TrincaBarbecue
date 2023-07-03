using AutoMapper;

using SummitPro.Application.Feature.CreateBarbecue;
using SummitPro.Application.UseCase.CreateBarbecue;
using SummitPro.Application.UseCase.GetBarbecueById;
using SummitPro.Core.Aggregate.Barbecue;

namespace SummitPro.Application.Mapping;

public class CreateBarbecueProfile : Profile
{
	public CreateBarbecueProfile()
	{
		CreateMap<CreateBarbecueInputBoundary, Barbecue>()
		.ConstructUsing(src => Barbecue.FactoryMethod(
				src.Description,
				src.AdditionalObservations,
				src.BeginDate,
				src.EndDate
			));

		CreateMap<Barbecue, CreateBarbecueCommandModel>()
			.ForMember(destination => destination.BarbecueIdentifier, map =>
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
			.ForMember(destination => destination.Description, map =>
			{
				map.MapFrom(src => src.Description);
			})
			.ForMember(destination => destination.Participants, map =>
			{
				map.MapFrom(src => src.Participants);
			})
			.ForMember(destination => destination.AdditionalObservations, map =>
			{
				map.MapFrom(src => src.AdditionalRemarks);
			});

		CreateMap<Barbecue, GetBarbecueByIdOutputBoundary>()
			.ForMember(destination => destination.BarbecueIdentifier, map =>
			{
				map.MapFrom(src => src.Identifier);
			})
			.ForMember(destination => destination.Description, map =>
			{
				map.MapFrom(src => src.Description);
			})
			.ForMember(destination => destination.BeginDateTime, map =>
			{
				map.MapFrom(src => src.BeginDate);
			})
			.ForMember(destination => destination.EndDateTime, map =>
			{
				map.MapFrom(src => src.EndDate);
			})
			.ForMember(destination => destination.AdditionalRemarks, map =>
			{
				map.MapFrom(src => src.AdditionalRemarks);
			})
			.ForMember(destination => destination.Participants, map =>
			{
				map.MapFrom(src => src.Participants);
			});
	}
}
