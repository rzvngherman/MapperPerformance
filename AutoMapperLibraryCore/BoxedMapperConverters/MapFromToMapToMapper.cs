using Boxed.Mapping;
using MapperPerformanceCore.Objects.test2;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperLibraryCore.BoxedMapperConverters
{
	public class MapFromToMapToMapper : IMapper<MapFrom, MapTo>
	{
		public void Map(MapFrom source, MapTo destination)
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

			destination = result;
		}
	}
}
