using TechShop.Inventory.Core.Enums.InventoryMovement;
using TechShop.Inventory.Core.Exceptions.StockItem;

namespace TechShop.Inventory.Core.Entities
{

	public class StockItem
	{
		public int IdStockItem { get; private set; }

		public int IdWarehouse { get; private set; }

		public string Sku { get; private set; }


		public int QuantityAvailable { get; private set; }

		public int QuantityReserved { get; private set; }

		public int QuantityTotal => QuantityAvailable + QuantityReserved;

		private readonly List<InventoryMovement> _movements = new();

		public IReadOnlyCollection<InventoryMovement> Movements => _movements;


		protected StockItem() { }
		// Constructor to create a new entity
		public StockItem(string sku, int idWarehouse)
		{
			if (string.IsNullOrWhiteSpace(sku)) throw new InvalidSkuException(sku);
			if (idWarehouse <= 0) throw new InvalidIdWarehouseException(idWarehouse);

			Sku = sku;
			IdWarehouse = idWarehouse;
			QuantityAvailable = 0;
			QuantityReserved = 0;
		}

		// Constructor to rehydrate a entity
		internal StockItem(int idStockItem, int idWarehouse, string sku, int quantityAvailable, int quantityReserved)
		{
			IdStockItem = idStockItem;
			IdWarehouse = idWarehouse;
			Sku = sku;
			QuantityAvailable = quantityAvailable;
			QuantityReserved = quantityReserved;
		}

		public void AddStock(int quantity)
		{
			validateQuantity(quantity);

			QuantityAvailable += quantity;

			RegisterMovement(this.IdStockItem, MovementType.IN, quantity, "Add Stock");
		}

		public void RemoveStock(int quantity, string reason)
		{
			validateQuantity(quantity);
			if (quantity > QuantityAvailable) throw new InsufficientStockException(Sku, quantity, QuantityAvailable);

			QuantityAvailable -= quantity;

			RegisterMovement(this.IdStockItem, MovementType.ADJUST, quantity, reason);
		}

		public void SellStock(int quantity, string referenceId)
		{
			validateQuantity(quantity);
			if (quantity > QuantityReserved) throw new InsufficientStockException(Sku, quantity, QuantityReserved);
			QuantityReserved -= quantity;

			RegisterMovement(this.IdStockItem, MovementType.OUT, quantity, "Sell stock", referenceId);
		}

		public void ReserveStock(int quantity)
		{
			validateQuantity(quantity);
			if (quantity > QuantityAvailable) throw new InsufficientStockException(Sku, quantity, QuantityAvailable);
			
			QuantityAvailable -= quantity;
			QuantityReserved += quantity;

			RegisterMovement(this.IdStockItem, MovementType.RESERVE, quantity, "Reserve Stock");
		}

		public void ReleaseStock(int quantity)
		{
			validateQuantity(quantity);
			if (quantity > QuantityReserved) throw new InsufficientStockException(Sku, quantity, QuantityReserved);
			
			QuantityReserved -= quantity;
			QuantityAvailable += quantity;

			RegisterMovement(this.IdStockItem, MovementType.RELEASE, quantity, "Release Stock");
		}

		private void RegisterMovement(int idStockItem, MovementType movementType, int quantity, string reason, string referenceId = null)
		{
			var movement = new InventoryMovement(
				idStockItem,
				movementType,
				quantity,
				reason,
				referenceId
			);

			_movements.Add(movement);
		}

		private void validateQuantity(int quantity)
		{
			if (quantity <= 0) throw new InvalidQuantityException(quantity);
		}
	}
	}
