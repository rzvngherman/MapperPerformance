using MapperPerformanceCore.Objects;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperLibraryCore.Mapster
{
	public class MapsterConfig : IRegister
	{
		public void Register(TypeAdapterConfig config)
		{
			config.NewConfig<SourceClass, DestinationClass>();

			config.ForType<SourceClass, DestinationClass>()
				.Map(y => y.DestinationClassId,				z => z.SourceClassId)
				.Map(y => y.CalculatedValue,				z => HelperMapper.XXX2(z.SourceClassId))
				.Map(y => y.Name,							z => HelperMapper.XXX3(z.FirstName, z.LastName));

			config.ForType<SourceChild, DestinationChild>()
				.Map(y => y.DestinationChildId,				z => HelperMapper.XXX(z.SourceChildId))
				.Map(y => y.DestinationNephews,				z => z.SourceNephews);

			config.ForType<SourceNephew, DestinationNephew>()
				.Map(y => y.Id,								z => z.Id)
				.Map(y => y.Name,							z => HelperMapper.XXX3(z.FirstName, z.LastName));
		}
	}
}
