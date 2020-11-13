using AgileObjects.AgileMapper.Configuration;
using MapperPerformanceCore.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperLibraryCore.AgileMapperConverters
{
	public class AgileConfiguration : MapperConfiguration
	{
		protected override void Configure()
		{
			// TSource, TTarget
			WhenMapping
				.From<SourceClass>()
				.To<DestinationClass>()
					.Map((dto, p) => HelperMapper.TestSetCalculatedValue(dto.SourceClassId))
					.To(p => p.CalculatedValue)
				.And
					.Map((dto, p) => HelperMapper.TestSetName(dto.FirstName, dto.LastName))
					.To(p => p.Name);

			WhenMapping
				.From<SourceChild>()
				.To<DestinationChild>()
					.Map((dto, p) => HelperMapper.TestSetDestinationChild(dto.SourceChildId))
					.To(p => p.DestinationChildId)
				.And
					.Map((dto, p) => dto.SourceNephews)
					.To(p => p.DestinationNephews);

			WhenMapping
				.From<SourceNephew>()
				.To<DestinationNephew>()
					.Map((dto, p) => HelperMapper.TestSetName(dto.FirstName, dto.LastName))
					.To(p => p.Name);
		}
	}
}
