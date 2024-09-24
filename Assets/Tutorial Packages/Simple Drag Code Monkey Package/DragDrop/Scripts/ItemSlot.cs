/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


/* Yes, the provided ItemSlot script is designed to attach a dragged item (like a potion sprite) to the slot sprite when it is 
dropped on the slot. Here's how it works:

Explanation of the ItemSlot Script:
Implements IDropHandler:

The IDropHandler interface is used to handle drop events in Unity's UI system.
OnDrop Method:

This method is called when an item is dropped onto the GameObject that this script is attached to (the slot sprite).
Logging:

Debug.Log("OnDrop"); logs a message to the console when an item is dropped onto the slot.
Checking for Dragged Item:

if (eventData.pointerDrag != null) { ... } checks if there is a dragged item.
Attaching the Item:

eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
This line sets the position of the dragged item's RectTransform to the position of the slot's RectTransform.
Essentially, it moves the dragged item to the slot's position, effectively attaching it to the slot.

How It Works in Your Unity Game:
Dragging the Item:

When you drag an item (like a potion sprite), the DragDrop script handles the dragging logic.
Dropping the Item:

When you drop the item onto the slot sprite, the OnDrop method of the ItemSlot script is triggered.
Attaching the Item:

The OnDrop method checks if there is a dragged item (eventData.pointerDrag != null).
If there is, it sets the dragged item's position to the slot's position, effectively attaching the item to the slot.

Summary:
Yes, the ItemSlot script does attach the item sprite (like the potion) to the slot sprite when it is dropped on the slot. The OnDrop 
method handles the drop event and moves the dragged item to the slot's position, making it appear as if the item is attached to the slot.

To modify the script so that it prints a debugging message when an item is attached to the slot sprite, you can add a Debug.Log 
statement inside the if block where the item is attached.

You can print the GameObject of the slot sprite that contains this script by using gameObject.name within the OnDrop
method.
*/
public class ItemSlot : MonoBehaviour, IDropHandler {

    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null) {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        
            //            // Print a message when an item is attached to the slot
            //            Debug.Log("Item attached to the slot.");
            // Print a message when an item is attached to the slot, including the GameObject name
            Debug.Log("Item attached to the slot: " + gameObject.name);
        }
    }

}
