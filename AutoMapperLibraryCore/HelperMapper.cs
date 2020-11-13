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
				DestinationChildId = Convert.ToInt32(TestSetDestinationChild(c.SourceChildId)),
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
				Name = TestSetName(n.FirstName, n.LastName).ToString()
			}));

			return results;
		}

		internal static List<SourceNephew> TestSetSourceNephews(int i)
		{
			var sourceNephews = new List<SourceNephew>
			{
				new SourceNephew { Id = i, FirstName = "aaa1", LastName = "bbb1" }
			};
			return sourceNephews;
		}

		internal static object TestSetDestinationChild(int sourceChildId)
		{
			return sourceChildId + 10;
		}

		internal static object TestSetCalculatedValue(int sourceClassId)
		{
			return sourceClassId * sourceClassId;
		}

		internal static object TestSetName(string firstName, string lastName)
		{
			return firstName + " " + lastName;
		}		
	}
}
