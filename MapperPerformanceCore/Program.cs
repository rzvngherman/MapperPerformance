using AutoMapper;
using AutoMapperLibrary;
using AutoMapperLibraryCore;
using Boxed.Mapping;
using MapperPerformanceCore.Objects;
using MapperPerformanceCore.Objects.test2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

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
		private List<Customer> _customers = new List<Customer>();
		private ICustomMapper _customMapper;

		private void DoMain(string[] args)
		{
			//Console.WriteLine("Test1");
			//Test1();
			//Console.WriteLine("");

			Console.WriteLine("Test2");
			Test2();

			// TODO https://rehansaeed.com/a-simple-and-fast-object-mapper/
			// TODO https://cezarypiatek.github.io/post/why-i-dont-use-automapper/

			Console.WriteLine("------- END.");
			Console.ReadLine();

		}

		private void Test1()
		{
			//Setup
			var h = new Test1Helper();
			var x = 1000000;
			h.PopulateCustomers(x);

			h.DoTest(x);			
		}
		
		private void Test2()
		{
			//Setup
			var h = new Test2Helper();
			var x = 1000000;
			h.PopulateData(x);

			h.DoTest(x);
		}	

		static void Main(string[] args)
		{
			var program = new Program();
			program.DoMain(args);
		}
	}
}
