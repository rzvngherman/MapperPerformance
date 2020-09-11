namespace MapperPerformanceCore.Objects
{
	public interface ICustomMapper
	{
		string MapperName { get; }
		T2 Map<T1, T2>(T1 customers) where T2 : class;
	}
}
