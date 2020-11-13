using AutoMapper;
using AutoMapperLibrary;
using AutoMapperLibraryCore;
using Boxed.Mapping;
using MapperPerformanceCore.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace MapperPerformanceCore
{
	/// <summary>
	/// Test with:
	/// 1) https://automapper.org/
	/// 2) http://tinymapper.net/
	/// 3) https://github.com/AgileObjects/AgileMapper
	/// 4) https://github.com/MapsterMapper/Mapster
	/// 5) https://www.nuget.org/packages/Boxed.Mapping/
	/// </summary>
	class Program
	{
		private readonly int _nrOfRows = 9000000;
		private ITestHelper _h;

		private void DoMain(string[] args)
		{
			Console.WriteLine("Date: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "	----------------------------------------------------------------------------------------------------------------");
			Console.WriteLine("------- BEGIN");

			DisplayClassFieldListNames();
			Console.WriteLine("");

			Console.WriteLine("Number of records " + _nrOfRows);
			Console.WriteLine("");

			_h = new Test4Helper(_nrOfRows);
			_h.DoTest();

			Console.WriteLine("Results: (miliseconds)");
			DisplayResultTimes(_h.Times);
			Console.WriteLine("");

			Console.WriteLine("------- END.");
			Console.ReadLine();
		}

		private void DisplayResultTimes(List<KeyValuePair<string, long>> times)
		{
			var orderList = times.OrderBy(t => t.Value);
			foreach (var item in orderList)
			{
				Console.Write(item.Key + " " + item.Value + "; ");
			}
			Console.WriteLine("");
		}

		private void DisplayClassFieldListNames()
		{
			Console.WriteLine("'SourceClass':");
			GetAllProperties(typeof(SourceClass), "   ");
			Console.WriteLine("");

			Console.WriteLine("'DestinationClass':");
			GetAllProperties(typeof(DestinationClass), "   ");
			Console.WriteLine("");
		}

		private void GetAllProperties(Type type, string separator)
		{
			var propertyInfos = type.GetProperties();
			foreach (PropertyInfo propertyInfo in propertyInfos)
			{
				var propType = propertyInfo.PropertyType;
				if (propType.IsGenericType)
				{
					if (propType.GetGenericTypeDefinition() == typeof(List<>))
					{
						Console.WriteLine(separator + propertyInfo.Name + " (List) :");
						var t3 = propType.GetGenericArguments().First();
						GetAllProperties(t3, separator + separator);
					}
				}
				else
				{
					Console.WriteLine(separator + propertyInfo.Name + " (" + propertyInfo.PropertyType.Name + ")");
				}
			}
		}

		static void Main(string[] args)
		{
			var program = new Program();
			program.DoMain(args);
		}
	}
}
