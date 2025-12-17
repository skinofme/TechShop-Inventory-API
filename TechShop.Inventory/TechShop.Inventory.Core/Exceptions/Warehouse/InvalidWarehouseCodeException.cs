using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Inventory.Core.Exceptions.Warehouse
{
	internal class InvalidWarehouseCodeException : DomainException
	{
		public InvalidWarehouseCodeException(string code) 
			: base($"Requested code: {code}, cannot be white space or empty")
		{
		}
	}
}
