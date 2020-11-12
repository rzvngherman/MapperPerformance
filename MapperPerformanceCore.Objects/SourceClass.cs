using System;
using System.Collections.Generic;
using System.Text;

namespace MapperPerformanceCore.Objects
{
	public class SourceClass
	{
		public int SId { get; set; }
	}

	public class DestinationClass
	{
		public int DId { get; set; }
		public long CalculatedValue { get; set; }
	}
}
