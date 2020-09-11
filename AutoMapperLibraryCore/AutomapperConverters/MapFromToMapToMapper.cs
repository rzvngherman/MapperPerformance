using AutoMapper;
using MapperPerformanceCore.Objects;
using MapperPerformanceCore.Objects.test2;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperLibraryCore.AutomapperConverters
{
	public class MapFromToMapToMapper : ITypeConverter<MapFrom, MapTo>
	{
		public MapTo Convert(MapFrom source, MapTo destination, ResolutionContext context)
		{
			if (source is null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			var result = HelperMapper.GetFrom(source);
			return result;			
		}
	}

	public class CustomerToCustomerViewItemMapper : ITypeConverter<Customer, CustomerViewItem>
	{
		public CustomerViewItem Convert(Customer source, CustomerViewItem destination, ResolutionContext context)
		{
			if (source is null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			var result = new CustomerViewItem
			{
				CustomerViewItemFirstName = source.FirstName,
				CustomerViewItemLastName = source.LastName,
				CustomerViewItemDateOfBirth = source.DateOfBirth,
				CustomerViewItemNumberOfOrders = source.NumberOfOrders,
			};

			return result;
		}
	}
}
