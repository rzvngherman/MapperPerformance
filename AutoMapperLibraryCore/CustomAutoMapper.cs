using MapperPerformanceCore.Objects;
using Mapster;

namespace AutoMapperLibrary
{
	public class CustomAutoMapper : ICustomMapper
	{
		private string _mapperName;
		public CustomAutoMapper()
		{
			_mapperName = "AutoMapper";
		}

		public string MapperName => _mapperName;

		private AutoMapper.IMapper _mapper;
		public void CreateMap<T1, T2>()
		{
			// AutoMapper(.net framework)
			//AutoMapper.Mapper.CreateMap<T1, T2>();

			//.net core
			var configuration = new AutoMapper.MapperConfiguration(cfg =>
			{
				cfg.CreateMap<T1, T2>();
			});
			// only during development, validate your mappings; remove it before release
			//configuration.AssertConfigurationIsValid();
			_mapper = configuration.CreateMapper();
		}

		public T2 Map<T1, T2>(T1 customers)
			where T2 : class
		{
			// AutoMapper
			var result = _mapper.Map<T2>(customers);
			return result;
		}
	}
}
