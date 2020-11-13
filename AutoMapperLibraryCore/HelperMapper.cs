using System;
using System.Collections.Generic;
using System.Globalization;
using MapperPerformanceCore.Objects;

namespace AutoMapperLibraryCore
{
	public class HelperMapper
	{
		public static DestinationClass GetFrom(SourceClass source)
		{
			var result = new DestinationClass
			{
				DestinationClassId = source.SourceClassId,
				CalculatedValue = source.SourceClassId * source.SourceClassId,
				Children = BuildChildren(source.Children)
			};
			return result;
		}

		private static List<DestinationChild> BuildChildren(List<SourceChild> children)
		{
			var results = new List<DestinationChild>();
			children.ForEach(c => results.Add(new DestinationChild
			{
				DestinationChildId = Convert.ToInt32(XXX(c.SourceChildId)),
				DestinationNephews = AddNephews(c.SourceNephews)
			}));

			return results;
		}

		public static List<DestinationNephew> AddNephews(List<SourceNephew> sourceNephews)
		{
			var results = new List<DestinationNephew>();
			sourceNephews.ForEach(n => results.Add(new DestinationNephew
			{
				Id = n.Id,
				Name = XXX3(n.FirstName, n.LastName).ToString()
			}));

			return results;
		}

		internal static object XXX(int sourceChildId)
		{
			return sourceChildId + 10;
		}

		internal static object XXX2(int sourceClassId)
		{
			return sourceClassId * sourceClassId;
		}

		internal static object XXX3(string firstName, string lastName)
		{
			return firstName + " " + lastName;
		}

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
	}
}
