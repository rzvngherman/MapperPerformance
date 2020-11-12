using System;
using System.Collections.Generic;
using System.Text;

namespace MapperPerformanceCore.Objects
{
	public class SourceClass
	{
		public int SourceClassId { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public List<SourceChild> Children { get; set; }
	}

	public class SourceChild
	{
		public int SourceChildId { get; set; }
		public List<SourceNephew> SourceNephews { get; set; }
	}

	public class SourceNephew
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
