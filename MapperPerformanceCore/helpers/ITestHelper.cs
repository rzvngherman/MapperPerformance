using MapperPerformanceCore.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapperPerformanceCore
{
	public interface ITestHelper
	{
		void DoTest();
		List<KeyValuePair<string, long>> Times { get; set; }

		void ValidateData();
	}
}
