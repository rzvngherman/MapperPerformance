using System;
using System.Globalization;
using MapperPerformanceCore.Objects.test2;

namespace AutoMapperLibraryCore
{
	public class HelperMapper
	{
		public static MapTo GetFrom(MapFrom source)
		{
			var result = new MapTo
			{
				MapToId = source.Id,
				MapToBooleanTo = source.BooleanFrom,
				MapToDateTimeOffsetTo = source.DateTimeOffsetFrom,
				MapToIntegerTo = source.IntegerFrom,
				MapToLongTo = source.LongFrom,
				MapToStringTo = source.StringFrom
			};
			return result;
		}

		public static MapFrom GenerateTestData(int i, Random random)
		{
			var mf = new MapFrom()
			{
				Id = i,
				BooleanFrom = random.NextDouble() > 0.5D,
				DateTimeOffsetFrom = DateTimeOffset.UtcNow,
				IntegerFrom = random.Next(),
				LongFrom = random.Next(),
				StringFrom = random.Next().ToString(CultureInfo.InvariantCulture),
			};

			//return new MapFrom()
			//{
			//	Id = i,
			//	BooleanFrom = i % 2 == 0 ? true : false,
			//	DateTimeOffsetFrom = DateTimeOffset.UtcNow,
			//	IntegerFrom = i,
			//	LongFrom = i,
			//	StringFrom = i.ToString()
			//};
			return mf;
		}
	}
}
