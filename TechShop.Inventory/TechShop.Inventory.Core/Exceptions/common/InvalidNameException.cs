using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Inventory.Core.Exceptions.common
{
	internal class InvalidNameException : DomainException
	{
		public InvalidNameException(string name)
			: base($"The requested name: {name}, cannot be a white space or be empty")
		{			
		}
	}
}
