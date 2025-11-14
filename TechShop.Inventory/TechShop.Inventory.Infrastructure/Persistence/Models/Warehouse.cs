using System;
using System.Collections.Generic;

namespace TechShop.Inventory.Infrastructure.Persistence.Models;

public partial class Warehouse
{
    public int IdWarehouse { get; set; }

    public string? Code { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public virtual ICollection<StockItem> StockItems { get; set; } = new List<StockItem>();
}
