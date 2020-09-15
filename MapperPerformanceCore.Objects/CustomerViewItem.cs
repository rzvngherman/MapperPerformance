using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperPerformanceCore.Objects
{
	public class CustomerViewItem
	{
		public string CustomerViewItemFirstName { get; set; }
		public string CustomerViewItemLastName { get; set; }
		public DateTime CustomerViewItemDateOfBirth { get; set; }
		public int CustomerViewItemNumberOfOrders { get; set; }
		public long MapToLong { get; set; }
	}
}
