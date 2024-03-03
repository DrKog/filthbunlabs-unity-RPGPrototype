using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<String, int> items = new Dictionary<String, int>();
    [SerializeField] private UIController canvas;

    public void AddItem(PickUpObject item)
    {
        if (items.ContainsKey(item.gameObject.name))
        {
            // Item of the same type already exists, so increment its quantity
            items[item.gameObject.name]++;
        }
        else
        {
            // Item does not exist in inventory, add it with quantity 1
            items.Add(item.gameObject.name, 1);
        }
        item.gameObject.SetActive(false);

        canvas.UpdateInventoryText();
    }
    
    public Dictionary<String, int> GetItems()
    {
        return items;
    }
}