using System;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private Inventory inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void PickUp()
    {
        inventory.AddItem(this); // Pass the current PickUpObject instance
    }
}