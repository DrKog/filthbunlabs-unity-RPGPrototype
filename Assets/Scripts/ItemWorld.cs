using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    private Item item;

    private SpriteRenderer _spriteRenderer;
    private TextMeshPro tmp;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        tmp = transform.Find("text").GetComponent<TextMeshPro>();
    }

    public void SetItem(Item item)
    {
        this.item = item;
        if (item.amount > 1)
        {
            tmp.SetText(item.amount.ToString());
        }
        else
        {
            tmp.SetText("");
        }
        _spriteRenderer.sprite = this.item.GetSprite();
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
