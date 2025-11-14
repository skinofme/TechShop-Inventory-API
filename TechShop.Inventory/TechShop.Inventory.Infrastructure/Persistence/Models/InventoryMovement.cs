using System;
using System.Collections.Generic;

namespace TechShop.Inventory.Infrastructure.Persistence.Models;

public partial class InventoryMovement
{
    public int IdInventoryMovement { get; set; }

    public int IdStockItem { get; set; }

    public string MovementType { get; set; } = null!;

    public int Quantity { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Reason { get; set; }

    public string? ReferenceId { get; set; }

    public virtual StockItem IdStockItemNavigation { get; set; } = null!;
}
