namespace TechShop.Inventory.Core.Exceptions.StockReservation
{
	public class InvalidIdStockItemException : DomainException
	{
		public InvalidIdStockItemException(int idStockItem)
			:base($"Invalid requested idStockItem:{idStockItem}, cannot be equal or less than zero.")
		{}
	}
}
