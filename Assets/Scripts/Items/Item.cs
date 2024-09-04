using UnityEngine;

/* This will handle the interactions with items in general (such as the 4 books for the puzzle).

This will make it so that, if I click on an item in my inventory, it will be equipped to the player, and removed from the 
inventory UI.

I WILL MODIFY THIS CODE SO THAT, once I click on an item, that item will be rendered at the position (1000, 1000, 1000).

Source of most of this code: Brackeys from https://youtu.be/HQNl3Ff2Lpo?si=71u8hLxbiQmP9R6h , https://youtu.be/YLhj7SfaxSE?si=zEufI5F7lrAOg6kD .
*/

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use ()
    {
        // Use the item
        // Something might happen

        Debug.Log("Using " + name);
    }

    // This will remove the item from the inventory when the player clicks on it. 
    // I WILL MODIFY THIS SO THAT the item will be rendered at the position (1000, 1000, 1000) instead of being removed from the inventory.
    public void RemoveFromInventory ()
    {
        Inventory.instance.Remove(this);
    }
}