using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Inventory.Core.Exceptions.common
{
	internal class InvalidQuantityException : Exception
	{
		public InvalidQuantityException(int invalidQuantity) 
			: base($"invalid requested quantity: {invalidQuantity}, quantity must be positive")
		{
		}
	}
}
