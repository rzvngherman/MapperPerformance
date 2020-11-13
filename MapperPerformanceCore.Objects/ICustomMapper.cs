using System.Collections.Generic;

namespace MapperPerformanceCore.Objects
{
	public interface ICustomMapper
	{
		string MapperName { get; }
		T2 MapGeneric<T1, T2>(T1 customers) where T2 : class;
		List<DestinationClass> Map(List<SourceClass> customers);
	}
}
