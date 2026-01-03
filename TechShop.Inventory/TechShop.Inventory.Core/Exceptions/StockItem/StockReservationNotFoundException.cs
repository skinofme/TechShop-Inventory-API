namespace TechShop.Inventory.Core.Exceptions.StockItem
{
	public class StockReservationNotFoundException : DomainException
	{
		public StockReservationNotFoundException(int idStockReservation)
			: base($"Stock reservation not found. IdStockReservation: {idStockReservation}")
		{
		}
	}
}
