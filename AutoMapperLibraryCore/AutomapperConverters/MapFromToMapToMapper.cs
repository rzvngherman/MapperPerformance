using AutoMapper;
using MapperPerformanceCore.Objects.test2;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperLibraryCore.AutomapperConverters
{
	public class MapFromToMapToMapper : ITypeConverter<MapFrom, MapTo>
	{
		public MapTo Convert(MapFrom source, MapTo destination, ResolutionContext context)
		{
			if (source is null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			var result = new MapTo
			{
				Id = source.Id,
				BooleanTo = source.BooleanFrom,
				DateTimeOffsetTo = source.DateTimeOffsetFrom,
				IntegerTo = source.IntegerFrom,
				LongTo = source.LongFrom,
				StringTo = source.StringFrom
			};

			return result;			
		}
	}
}
