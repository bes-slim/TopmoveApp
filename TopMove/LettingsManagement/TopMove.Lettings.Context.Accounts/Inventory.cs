using System;
using System.Collections.Generic;
using System.Linq;
using TopMove.Infrastructure;

namespace TopMove.Lettings.Context.Accounts
{
    public class InventoryItem : ValueObject<InventoryItem>
    {
        public InventoryItem(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public string Name { get; set; }
        public string Description { get; set; }
       
    }
    public class Inventory : Entity<Guid>
    {
        List<InventoryItem> _inventoryItems = new List<InventoryItem>();
        public Inventory(Guid id, Guid userId, Guid propertyId)
        {
            Id = id;
            CreatedBy = userId;
            PropertyId = propertyId;
        }

        public Guid PropertyId { get; set; }

        public Guid CreatedBy { get; set; }
        public void AddInventoryItem(InventoryItem inventoryItem)
        {
            if (_inventoryItems.All(i =>  !i.Equals(inventoryItem)))
                _inventoryItems.Add(inventoryItem);

        }

        public void EditInventoryItem(InventoryItem inventoryItem)
        {
            if (_inventoryItems.All(i => i.Name != inventoryItem.Name)) return;
            var item = _inventoryItems.Single(i => i.Equals(inventoryItem));
            item.Description = inventoryItem.Description;
        }

       
    }
}