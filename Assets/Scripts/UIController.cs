using System;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class UIController : MonoBehaviour
{
    public TMP_Text inventoryPanel;

    private Inventory inventory;

    private void Start()
    {
        inventoryPanel.gameObject.SetActive(false);
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void ToggleInventoryPanel()
    {
        if (inventoryPanel.gameObject.activeSelf)
        {
            inventoryPanel.gameObject.SetActive(false);
        }
        else
        {
            inventoryPanel.gameObject.SetActive(true);
        }
    }

    public void UpdateInventoryText()
    {
        string inventoryContent = "Inventory:\n";
        Dictionary<String, int> items = inventory.GetItems();
        foreach (var item in items)
        {
            inventoryContent += "- " + item.Key + " (Quantity: " + item.Value + ")\n";
        }
        inventoryPanel.text = inventoryContent; 
    }
}
