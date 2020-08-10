using System;
using System.Collections.Generic;
using System.Text;

namespace CSVParser.Models
{
	internal class Customer
	{
		public string UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Version { get; set; }
		public string InsuranceCompany { get; set; }
	}
}
