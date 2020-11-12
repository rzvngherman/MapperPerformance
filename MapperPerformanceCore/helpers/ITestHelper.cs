using System;
using System.Collections.Generic;
using System.Text;

namespace MapperPerformanceCore
{
	public interface ITestHelper
	{
		void PopulateCustomers(int count);
		void DoTest(int x);
		List<KeyValuePair<string, long>> Times { get; set; }
	}
}
