using System;
using System.Collections.Generic;
using System.Text;

namespace MapperPerformanceCore.Objects
{
	public class DestinationClass
	{
		public int DestinationClassId { get; set; }
		public long CalculatedValue { get; set; }
		public string Name { get; set; }
		public List<DestinationChild> Children { get; set; }
	}

	public class DestinationChild
	{
		public int DestinationChildId { get; set; }
		public List<DestinationNephew> DestinationNephews { get; set; }
	}

	public class DestinationNephew
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
