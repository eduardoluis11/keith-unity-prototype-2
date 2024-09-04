using UnityEngine;
using UnityEngine.UI;

/* Script that will allow me to add and remove items from a single slot in my Inventory.
 * 
 * Source of most of this code: Brackeys from https://youtu.be/YLhj7SfaxSE?si=zEufI5F7lrAOg6kD .
 */

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);

        // // Apparently, by sending the item's Transform to the RemoveFromInventory method, I will be able to make the
        // // item to be rendered at the position (1000, 1000, 1000).
        // // THIS MAY NOT WORK, SO I MAY DELETE THIS LATER.
        // item.RemoveFromInventory(transform);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

}
