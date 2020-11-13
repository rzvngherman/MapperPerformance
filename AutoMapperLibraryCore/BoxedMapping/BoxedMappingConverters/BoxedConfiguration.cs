using Boxed.Mapping;
using MapperPerformanceCore.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperLibraryCore
{
	public class SourceMapper : Boxed.Mapping.IMapper<SourceClass, DestinationClass>
	{
		private readonly IMapper<SourceChild, DestinationChild> _childMapper;

		public SourceMapper()
		{
			var nephewMapper = new SourceNephewMapper();
			var childMapper = new SourceChildMapper(nephewMapper);
			_childMapper = childMapper;
		}

		public void Map(SourceClass source, DestinationClass destination)
		{
			destination.DestinationClassId = source.SourceClassId;
			destination.CalculatedValue = Convert.ToInt64(HelperMapper.XXX2(source.SourceClassId));
			destination.Name = HelperMapper.XXX3(source.FirstName, source.LastName).ToString();

			destination.Children = _childMapper.MapList(source.Children);
		}
	}

	public class SourceChildMapper : IMapper<SourceChild, DestinationChild>
	{
		private readonly IMapper<SourceNephew, DestinationNephew> _nephewMapper;

		public SourceChildMapper(IMapper<SourceNephew, DestinationNephew> nephewMapper) => _nephewMapper = nephewMapper;

		public void Map(SourceChild source, DestinationChild destination)
		{
			destination.DestinationChildId = Convert.ToInt32(HelperMapper.XXX(source.SourceChildId));
			destination.DestinationNephews = _nephewMapper.MapList(source.SourceNephews);
		}
	}

	public class SourceNephewMapper : IMapper<SourceNephew, DestinationNephew>
	{
		public void Map(SourceNephew source, DestinationNephew destination)
		{
			destination.Id = source.Id;
			destination.Name = HelperMapper.XXX3(source.FirstName, source.LastName).ToString();
		}
	}
}
