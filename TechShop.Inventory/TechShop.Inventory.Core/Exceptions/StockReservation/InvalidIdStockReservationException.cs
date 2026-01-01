using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Inventory.Core.Exceptions.StockReservation
{
	public class InvalidIdStockReservationException : DomainException
	{
		public InvalidIdStockReservationException(int idStockReservation)
			: base($"Invalid requested IdstockReservation: {idStockReservation}, cannot be equal or less than zero.")
		{ }
	}
}
