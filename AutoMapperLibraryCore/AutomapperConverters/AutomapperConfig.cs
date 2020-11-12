using AutoMapper;
using MapperPerformanceCore.Objects;

namespace AutoMapperLibraryCore.AutomapperConverters
{
	public class AutomapperConfig : Profile
	{
		public AutomapperConfig()
		{
			//(TSource, TDestination)
			CreateMap<SourceClass, DestinationClass>()
						.ForMember(y => y.DId,					y => y.MapFrom(z => z.SId))
						.ForMember(y => y.CalculatedValue,		y => y.MapFrom(z => z.SId * z.SId));

			//CreateMap<MapFrom, MapTo>()
			//			.ForMember(y => y.MapToBooleanTo,			y => y.MapFrom(z => z.BooleanFrom))
			//			.ForMember(y => y.MapToDateTimeOffsetTo,	y => y.MapFrom(z => z.DateTimeOffsetFrom))
			//			.ForMember(y => y.MapToIntegerTo,			y => y.MapFrom(z => z.IntegerFrom))
			//			.ForMember(y => y.MapToLongTo,				y => y.MapFrom(z => z.LongFrom))
			//			.ForMember(y => y.MaptToLong2,				y => y.MapFrom(z => z.Id * z.IntegerFrom))
			//			.ForMember(y => y.MapToChildred,			y => y.MapFrom(z => z.MapFromChildred));
			//CreateMap<MapFromChild, MapToChild>()
			//			.ForMember(y => y.ChildMapToId, y => y.MapFrom(z => z.Id))
			//			.ForMember(y => y.ChildBooleanFrom, y => y.MapFrom(z => z.BooleanFrom));

			////2)
			//CreateMap<Customer, CustomerViewItem>().ConvertUsing<CustomerToCustomerViewItemMapper>();
			////CreateMap<MapFrom, MapTo>()
			////	.ForMember(y => y.BooleanTo, y => y.MapFrom(z => z.BooleanFrom))
			////	.ForMember(y => y.DateTimeOffsetTo, y => y.MapFrom(z => z.DateTimeOffsetFrom))
			////	.ForMember(y => y.IntegerTo, y => y.MapFrom(z => z.IntegerFrom))
			////	.ForMember(y => y.LongTo, y => y.MapFrom(z => z.LongFrom));
		}
	}
}
