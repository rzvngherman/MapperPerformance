using MapperPerformanceCore.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace AutoMapperLibraryCore.TinyMapperConverters
{
	public sealed class SourceClassConverterList : TypeConverter
	{
		public SourceClassConverterList()
		{
			TypeDescriptor.AddAttributes(typeof(SourceClass), new TypeConverterAttribute(typeof(SourceClassConverter)));
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(List<DestinationClass>);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			var concreteValue = (List<SourceClass>)value;
			var results = new List<DestinationClass>();

			Nelibur.ObjectMapper.TinyMapper.Bind<SourceClass, DestinationClass>();
			foreach (var val in concreteValue)
			{
				var result = Nelibur.ObjectMapper.TinyMapper.Map<DestinationClass>(val);
				results.Add(result);
			}
			return results;
		}
	}

	public sealed class SourceClassConverter : TypeConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(DestinationClass);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			var concreteValue = (SourceClass)value;
			var result = new DestinationClass
			{
				DestinationClassId = concreteValue.SourceClassId,
				CalculatedValue = Convert.ToInt64(HelperMapper.TestSetCalculatedValue(concreteValue.SourceClassId)),
				Name = HelperMapper.TestSetName(concreteValue.FirstName, concreteValue.LastName).ToString()
			};

			var destChildren = new List<DestinationChild>();
			concreteValue.Children.ForEach(c => destChildren.Add(new DestinationChild
			{
				DestinationChildId = Convert.ToInt32(HelperMapper.TestSetDestinationChild(c.SourceChildId)),
				DestinationNephews = HelperMapper.AddNephews(c.SourceNephews)
			}));

			result.Children = destChildren;

			return result;
		}
	}
}
