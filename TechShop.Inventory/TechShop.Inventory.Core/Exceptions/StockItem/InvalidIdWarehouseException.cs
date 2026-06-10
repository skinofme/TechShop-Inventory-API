namespace TechShop.Inventory.Core.Exceptions.StockItem
{
	public class InvalidIdWarehouseException : DomainException
	{
		public InvalidIdWarehouseException(Guid idWarehouse)
			:base($"Invalid requested IdWarehouse: {idWarehouse}, cannot be empty.")
		{
		}
	}
}
