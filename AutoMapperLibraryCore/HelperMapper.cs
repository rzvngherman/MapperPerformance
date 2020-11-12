using System;
using System.Globalization;
using MapperPerformanceCore.Objects;

namespace AutoMapperLibraryCore
{
	public class HelperMapper
	{
		//public static MapTo GetFrom(MapFrom source)
		//{
		//	var result = new MapTo
		//	{
		//		MapToId = source.Id,
		//		MapToBooleanTo = source.BooleanFrom,
		//		MapToDateTimeOffsetTo = source.DateTimeOffsetFrom,
		//		MapToIntegerTo = source.IntegerFrom,
		//		MapToLongTo = source.LongFrom,
		//		MapToStringTo = source.StringFrom,
		//		MaptToLong2 = source.Id * source.IntegerFrom
		//	};
		//	return result;
		//}

		//public static CustomerViewItem GetFrom(Customer source)
		//{
		//	var result = new CustomerViewItem
		//	{
		//		CustomerViewItemFirstName = source.FirstName,
		//		CustomerViewItemLastName = source.LastName,
		//		CustomerViewItemDateOfBirth = source.DateOfBirth,
		//		CustomerViewItemNumberOfOrders = source.NumberOfOrders,
		//		MapToLong = source.NumberOfOrders * source.NumberOfOrders
		//	};

		//	return result;
		//}

		//public static MapFrom GenerateTestData(int i, Random random)
		//{
		//	var mf = new MapFrom()
		//	{
		//		Id = i,
		//		BooleanFrom = random.NextDouble() > 0.5D,
		//		DateTimeOffsetFrom = DateTimeOffset.UtcNow,
		//		IntegerFrom = random.Next(),
		//		LongFrom = random.Next(),
		//		StringFrom = random.Next().ToString(CultureInfo.InvariantCulture),				
		//	};

		//	var id1 = -i;
		//	var id2 = -(2 * i);
		//	var x = new System.Collections.Generic.List<MapFromChild>
		//	{
		//		new MapFromChild { Id = id1, BooleanFrom = random.NextDouble() > 0.5D },
		//		new MapFromChild { Id = id2, BooleanFrom = random.NextDouble() > 0.5D }
		//	};

		//	mf.MapFromChildred = x;
		//	return mf;
		//}

		public static SourceClass GenerateTestData2(int i, Random random)
		{
			var mf = new SourceClass()
			{
				SId = i
			};

			return mf;
		}

		public static DestinationClass GetFrom(SourceClass source)
		{
			var result = new DestinationClass
			{
				DId = source.SId,
				CalculatedValue = source.SId * source.SId
			};
			return result;
		}
	}
}
