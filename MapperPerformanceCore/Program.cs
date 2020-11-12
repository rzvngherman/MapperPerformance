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

			Console.WriteLine("Number of records " + _nrOfRows);
			Console.WriteLine("");

			_h = new Test4Helper();
			Test1();

			// TODO https://rehansaeed.com/a-simple-and-fast-object-mapper/
			// TODO https://cezarypiatek.github.io/post/why-i-dont-use-automapper/

			Console.WriteLine("------- END.");
			Console.ReadLine();
		}

		private void Test1()
		{
			//Setup
			_h.PopulateCustomers(_nrOfRows);
			
			_h.DoTest(_nrOfRows);

			DisplayResult(_h.Times);			
		}

		private void DisplayResult(List<KeyValuePair<string, long>> times)
		{
			var orderList = times.OrderBy(t => t.Value);
			foreach (var item in orderList)
			{
				Console.Write(item.Key + " " + item.Value + "; ");
			}
			Console.WriteLine("");
		}

		static void Main(string[] args)
		{
			var program = new Program();
			program.DoMain(args);
		}
	}
}
