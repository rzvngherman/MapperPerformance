using System;
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
						.ForMember(y => y.DestinationClassId,		y => y.MapFrom(z => z.SourceClassId))
						.ForMember(y => y.CalculatedValue,			y => y.MapFrom(z => HelperMapper.TestSetCalculatedValue(z.SourceClassId)))
						.ForMember(y => y.Name,						y => y.MapFrom(z => HelperMapper.TestSetName(z.FirstName, z.LastName)));

			CreateMap<SourceChild, DestinationChild>()
						.ForMember(y => y.DestinationChildId, y => y.MapFrom(z => HelperMapper.TestSetDestinationChild(z.SourceChildId)))
						.ForMember(y => y.DestinationNephews, y => y.MapFrom(z => z.SourceNephews));

			CreateMap<SourceNephew, DestinationNephew>()
						.ForMember(y => y.Id,						y => y.MapFrom(z => z.Id))
						.ForMember(y => y.Name,						y => y.MapFrom(z => HelperMapper.TestSetName(z.FirstName, z.LastName)));

		}
	}
}
