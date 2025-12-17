using TechShop.Inventory.Core.Exceptions.common;
using TechShop.Inventory.Core.Exceptions.Warehouse;

namespace TechShop.Inventory.Core.Entities
{
	public class Warehouse
	{
		public int IdWarehouse { get; private set; }

		public string Code { get; private set; }

		public string Name { get; private set; }

		public string Location { get; private set; }


		protected Warehouse() { }

		// constructor to create a new entity
		public Warehouse(string code, string name, string location)
		{
			if(string.IsNullOrWhiteSpace(code)) throw new InvalidWarehouseCodeException(code);
			if(string.IsNullOrWhiteSpace(name)) throw new InvalidNameException(name);
			if(string.IsNullOrWhiteSpace(location)) throw new InvalidLocationException(location);

			Code = code;
			Name = name;
			Location = location;
		}

		// constructor to rehydrate the entity
		internal Warehouse(int idWarehouse, string code, string name, string location)
			:this(code, name, location)
		{
			if (idWarehouse <= 0) throw new InvalidIdException(idWarehouse);

			IdWarehouse = idWarehouse;
		}
	}
}
