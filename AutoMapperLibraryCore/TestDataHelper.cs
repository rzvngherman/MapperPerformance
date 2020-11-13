using MapperPerformanceCore.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AutoMapperLibraryCore
{
	public class TestDataHelper
	{
		private readonly int _nrOfRows;

		private TestDataHelper()
		{
		}

		public TestDataHelper(int nrOfRows)
		{
			_nrOfRows = nrOfRows;
		}

		public List<SourceClass> PopulateTestData()
		{
			var mapFrom = new List<SourceClass>();
			var random = new Random();
			for (int x = 1; x < _nrOfRows + 1; x++)
			{
				var customer = GetCustomerFromDB(x, random);
				mapFrom.Add(customer);
			}
			return mapFrom;
		}

		private SourceClass GetCustomerFromDB(int i, Random random)
		{
			var mf = new SourceClass()
			{
				SourceClassId = i,
				FirstName = random.Next().ToString(CultureInfo.InvariantCulture),
				LastName = random.Next().ToString(CultureInfo.InvariantCulture),
				Children = new List<SourceChild>
				{
					new SourceChild{SourceChildId = 1,SourceNephews = XXX4(i)},
					new SourceChild{ SourceChildId = 2, SourceNephews = XXX4(i)}
				}
			};

			return mf;
		}

		private List<SourceNephew> XXX4(int i)
		{
			var sourceNephews = new List<SourceNephew>
			{
				new SourceNephew { Id = i, FirstName = "aaa1", LastName = "bbb1" }
			};
			return sourceNephews;
		}
	}
}
