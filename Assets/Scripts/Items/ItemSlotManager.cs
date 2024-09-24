using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/* Script for the Empty Game Object that act as Containers for each pair of Book Sprite and Slot Sprite. It calls
the ItemSlot.cs script, which is attached to the Slot Sprite Game Object.

This will detect the name of the Book sprite that was attached to a Slot sprite, and print the name of the Book sprite
and of the Slot Sprite in a message to the console.

To achieve this, you can create a new script that will be attached to the Empty GameObject container. This script will
listen for the OnDrop event from the ItemSlot script and print a debugging message based on the names of the item sprite
and slot sprite GameObjects.

Attach the ItemSlotManager script to the Empty GameObject container. This setup will allow the ItemSlot script to
notify the ItemSlotManager script whenever an item is dropped into a slot, and the ItemSlotManager script will print
the appropriate debugging message.
*/

public class ItemSlotManager : MonoBehaviour
{

    // This method will be called by the ItemSlot script when an item is dropped
    public void OnItemDropped(GameObject item, GameObject slot)
    {
        if (item.name == "potion" && slot.name == "potion slot")
        {
            Debug.Log("You've attached the Potion into the Potion Slot.");
        }
        else
        {
            Debug.Log($"You've attached the {item.name} into the {slot.name}.");
        }
    }

}
