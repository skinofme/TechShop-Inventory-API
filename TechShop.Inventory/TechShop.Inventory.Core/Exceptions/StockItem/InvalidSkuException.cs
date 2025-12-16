using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Inventory.Core.Exceptions.StockItem
{
	internal class InvalidSkuException : DomainException
	{
		public InvalidSkuException(string sku) 
			: base($"The requested SKU: {sku} cannot be a white space or be empty")
		{ }
	}
}
