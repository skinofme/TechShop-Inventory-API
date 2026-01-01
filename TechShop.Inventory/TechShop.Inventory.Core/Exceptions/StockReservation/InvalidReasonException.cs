using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Inventory.Core.Exceptions.StockReservation
{
	public class InvalidReasonException : DomainException
	{
		public InvalidReasonException(string reason)
			:base($"Invalid requested reason: {reason}, cannot be null or empty space.")
		{ }
	}
}
