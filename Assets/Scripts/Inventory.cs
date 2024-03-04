using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{

    public event EventHandler OnItemListChabge;
    
    private List<Item> _items;

    public Inventory()
    {
        _items = new List<Item>();
        
        Debug.Log(_items.Count);
    }

    public void AddItem(Item item)
    {
        if (item.isStackable())
        {
            bool itemInInventory = false;
            foreach (Item inInventory in _items)
            {
                if (item.itemTyoe == inInventory.itemTyoe)
                {
                    inInventory.amount += item.amount;
                    itemInInventory = true;
                }
            }
            if (!itemInInventory)
            {
                _items.Add(item);
            }
        }
        else
        {
            _items.Add(item);
        }
        
        OnItemListChabge?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return _items;
    }
}
