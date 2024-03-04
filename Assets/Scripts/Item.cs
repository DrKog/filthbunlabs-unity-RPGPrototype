using System;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemTyoe
    {
        SQUARE,
        TRIANGEL
    }

    public ItemTyoe itemTyoe;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemTyoe)
        {
            default:
            case ItemTyoe.SQUARE: return ItemAssets.Instance.squareSprite;
            case ItemTyoe.TRIANGEL: return ItemAssets.Instance.triangleSprite;
        }
    }

    public bool isStackable()
    {
        switch (itemTyoe)
        {
            default:
            case ItemTyoe.SQUARE: return true;
            case ItemTyoe.TRIANGEL: return false;
        }
    }
}
