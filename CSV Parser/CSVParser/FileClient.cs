using CsvHelper;
using CSVParser.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CSVParser
{
	internal static class FileClient
	{
		public static List<Customer> ParseCustomers(string file)
		{
			using (var reader = new StreamReader(file))
			{
				using(var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
				{
					return csv.GetRecords<Customer>().ToList();
				}
			}
		}

		public static void WriteCustomersToFile(IEnumerable<Customer> customers, string file)
		{
			using (var writer = new StreamWriter(file))
			{
				using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
				{
					csv.WriteRecords(customers);
				}
			}
		}
	}
}
