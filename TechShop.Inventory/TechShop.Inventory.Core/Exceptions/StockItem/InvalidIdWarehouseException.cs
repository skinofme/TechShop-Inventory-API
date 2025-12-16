namespace TechShop.Inventory.Core.Exceptions.StockItem
{
	internal class InvalidIdWarehouseException : DomainException
	{
		public InvalidIdWarehouseException(int idWarehouse)
			: base($"Invalid requested IdWarehouse: {idWarehouse}, cannot be equal or less than zero")
		{ }
	}
}
