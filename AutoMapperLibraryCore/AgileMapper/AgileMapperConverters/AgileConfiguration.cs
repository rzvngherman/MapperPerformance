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
			// Configure default Mapper ProductDto -> Product mapping:
			// TSource, TTarget
			WhenMapping
				.From<SourceClass>()
				.To<DestinationClass>()
					//.Map((dto, p) => dto.SourceClassId)
					//.To(p => p.DestinationClassId)
				
				//.And
				//.Ignore(p => p.Price, p => p.CatNum)

				//.And
					.Map((dto, p) => HelperMapper.XXX2(dto.SourceClassId))
					.To(p => p.CalculatedValue)

				.And
					.Map((dto, p) => HelperMapper.XXX3(dto.FirstName, dto.LastName))
					.To(p => p.Name)
				;

			WhenMapping
				.From<SourceChild>()
				.To<DestinationChild>()
					.Map((dto, p) => HelperMapper.XXX(dto.SourceChildId))
					.To(p => p.DestinationChildId)
				.And
					.Map((dto, p) => dto.SourceNephews)
					.To(p => p.DestinationNephews)
				;

			WhenMapping
				.From<SourceNephew>()
				.To<DestinationNephew>()
					.Map((dto, p) => HelperMapper.XXX3(dto.FirstName, dto.LastName))
					.To(p => p.Name)
					;
			// Cache all Product -> ProductDto mapping plans:
			//GetPlansFor<DestinationClass>().To<SourceClass>();
		}
	}
}
