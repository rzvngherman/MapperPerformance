using MapperPerformanceCore.Objects;

namespace AutoMapperLibrary
{
	public class CustomAutoMapper : ICustomMapper
	{
		public CustomAutoMapper()
		{
			MapperName = "AutoMapper";

			var configuration = new AutoMapper.MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new AutoMapperLibraryCore.AutomapperConverters.AutomapperConfig());
			});
			_mapper = configuration.CreateMapper();
		}

		public string MapperName { get; set; }
		public AutoMapper.IMapper _mapper;

		public T2 MapGeneric<T1, T2>(T1 customers)
			where T2 : class
		{
			throw new System.NotImplementedException();
		}

		public DestinationClass Map<SourceClass, DestinationClass>(SourceClass customers) where DestinationClass : class
		{
			var result = _mapper.Map<DestinationClass>(customers);
			return result;
		}
	}
}
