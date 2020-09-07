﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperPerformanceCore.Objects
{
	public class Customer
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }

		public int NumberOfOrders { get; set; }
	}
}
