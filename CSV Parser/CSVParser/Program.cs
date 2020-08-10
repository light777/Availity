using CSVParser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSVParser
{
	class Program
	{
		static int Main(string[] args)
		{
			if (args.Length == 0)
			{
				Console.WriteLine("Please enter a filename.");
				Console.WriteLine("Usage: CSVParser <filename>");
				return 1;
			}

			if (!File.Exists($"{Environment.CurrentDirectory}/{args[0]}"))
			{
				Console.WriteLine("Please enter a filename that exists.");
				Console.WriteLine("Usage: CSVParser <filename>");
				return 1;
			}

			try
			{
				var customers = FileClient.ParseCustomers($"{Environment.CurrentDirectory}/{args[0]}");
				Dictionary<string, List<Customer>> customersDict = SeperateCustomersIntoCompanies(customers);
				WriteCustomerFiles(customersDict);

				return 0;
			} catch (Exception exc)
			{
				Console.WriteLine("An Error Occurred:");
				Console.WriteLine(exc.Message);
				Console.WriteLine(exc.StackTrace);
				return 1;
			}
		}

		private static Dictionary<string, List<Customer>> SeperateCustomersIntoCompanies(IEnumerable<Customer> customers)
		{
			var customersDict = new Dictionary<string, List<Customer>>();
			foreach (var customer in customers)
			{
				if (!customersDict.Keys.Contains(customer.InsuranceCompany))
				{
					customersDict.Add(customer.InsuranceCompany, new List<Customer>());
				}

				var existingCustomer = customersDict[customer.InsuranceCompany].FirstOrDefault(c => c.UserId == customer.UserId);
				if (existingCustomer != null)
				{
					if (customer.Version > existingCustomer.Version)
					{
						var customersInCompany = customersDict[customer.InsuranceCompany];
						customersInCompany[customersInCompany.IndexOf(existingCustomer)] = customer;
					}
				}
				else
				{
					customersDict[customer.InsuranceCompany].Add(customer);
				}
			}

			return customersDict;
		}

		private static void WriteCustomerFiles(Dictionary<string, List<Customer>> customersDict)
		{
			foreach (var key in customersDict.Keys)
			{
				FileClient.WriteCustomersToFile(customersDict[key].OrderBy(c => c.LastName).ThenBy(c => c.FirstName), $"{Environment.CurrentDirectory}/{key}.csv");
			}
		}
	}
}
