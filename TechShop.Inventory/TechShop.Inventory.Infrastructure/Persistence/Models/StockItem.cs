using System;
using System.Collections.Generic;

namespace TechShop.Inventory.Infrastructure.Persistence.Models;

public partial class StockItem
{
    public int IdStockItem { get; set; }

    public int IdWarehouse { get; set; }

    public string Sku { get; set; } = null!;

    public int QuantityAvailable { get; set; }

    public int QuantityReserved { get; set; }

    public DateTime LastUpdated { get; set; }

    public virtual Warehouse IdWarehouseNavigation { get; set; } = null!;

    public virtual ICollection<InventoryMovement> InventoryMovements { get; set; } = new List<InventoryMovement>();
}
