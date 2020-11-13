using System.Collections.Generic;

namespace MapperPerformanceCore.Objects
{
	public interface ICustomMapper
	{
		string MapperName { get; }
		List<DestinationClass> Map(List<SourceClass> customers);
	}
}
