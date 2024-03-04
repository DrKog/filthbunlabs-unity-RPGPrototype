using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Adjust this value to control the speed of the player
    [SerializeField] private UI_inventory _uiInventory;
    
    private Rigidbody2D rb;
    private Inventory inventory;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inventory = new Inventory();
        _uiInventory.SetInventory(inventory);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ItemWorld itemWorld = other.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }

    private void Update()
    {
        // Input
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Movement
        Vector2 movement = new Vector2(moveX, moveY).normalized;
        rb.velocity = movement * moveSpeed;
    }
}
