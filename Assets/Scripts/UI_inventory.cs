using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_inventory : MonoBehaviour
{

    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTempalet;

    private void Start()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        Debug.Log(transform.position);
        itemSlotTempalet = itemSlotContainer.Find("ItemSlot");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChabge += Inventory_OnItemListChange;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChange(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if(child == itemSlotTempalet) continue;
            
            Destroy(child.gameObject);
            
        }
        
        
        int x = 0;
        int y = 0;
        float itemSize = 55f;
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlothTransform = Instantiate(itemSlotTempalet, itemSlotContainer).GetComponent<RectTransform>();
            itemSlothTransform.gameObject.SetActive(true);
            itemSlothTransform.anchoredPosition = new Vector2(x * itemSize, y * itemSize);
            Image image = itemSlothTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            TextMeshProUGUI text = itemSlothTransform.Find("Amount").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1)
            {
                text.SetText(item.amount.ToString());
            }
            else
            {
                text.SetText("");
            }

            x++;
        }
    }
}
