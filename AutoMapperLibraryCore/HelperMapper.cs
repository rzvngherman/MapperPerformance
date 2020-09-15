using System;
using System.Globalization;
using MapperPerformanceCore.Objects;
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
				MapToStringTo = source.StringFrom,
				MaptToLong2 = source.Id * source.IntegerFrom
			};
			return result;
		}

		public static CustomerViewItem GetFrom(Customer source)
		{
			var result = new CustomerViewItem
			{
				CustomerViewItemFirstName = source.FirstName,
				CustomerViewItemLastName = source.LastName,
				CustomerViewItemDateOfBirth = source.DateOfBirth,
				CustomerViewItemNumberOfOrders = source.NumberOfOrders,
				MapToLong = source.NumberOfOrders * source.NumberOfOrders
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
			return mf;
		}
	}
}
