using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Inventory.Core.Exceptions.Warehouse
{
	internal class InvalidLocationException : DomainException
	{
		public InvalidLocationException(string location)
			: base($"The requested location: {location}, cannot be a white space or be empty")
		{
		}
	}
}
