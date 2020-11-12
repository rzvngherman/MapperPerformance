namespace MapperPerformanceCore.Objects
{
	public interface ICustomMapper
	{
		string MapperName { get; }
		T2 MapGeneric<T1, T2>(T1 customers) where T2 : class;
		DestinationClass Map<SourceClass, DestinationClass>(SourceClass customers) where DestinationClass : class;
	}
}
