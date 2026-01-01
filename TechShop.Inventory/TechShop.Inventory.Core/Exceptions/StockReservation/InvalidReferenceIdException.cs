namespace TechShop.Inventory.Core.Exceptions.StockReservation
{
	public class InvalidReferenceIdException : DomainException
	{
		public InvalidReferenceIdException(string referenceId)
			:base($"Invalid requested referenceId: {referenceId}, cannot be null or empty space.")
		{}
	}
}
