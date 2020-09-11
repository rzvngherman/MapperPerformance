using AutoMapper;
using MapperPerformanceCore.Objects;
using MapperPerformanceCore.Objects.test2;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperLibraryCore.AutomapperConverters
{
	public class AutomapperConfig : Profile
	{
		public AutomapperConfig()
		{
			CreateMap<MapFrom, MapTo>().ConvertUsing<MapFromToMapToMapper>();
			CreateMap<Customer, CustomerViewItem>().ConvertUsing<CustomerToCustomerViewItemMapper>();

			//CreateMap<MapFrom, MapTo>()
			//	.ForMember(y => y.BooleanTo, y => y.MapFrom(z => z.BooleanFrom))
			//	.ForMember(y => y.DateTimeOffsetTo, y => y.MapFrom(z => z.DateTimeOffsetFrom))
			//	.ForMember(y => y.IntegerTo, y => y.MapFrom(z => z.IntegerFrom))
			//	.ForMember(y => y.LongTo, y => y.MapFrom(z => z.LongFrom));
		}
	}
}
