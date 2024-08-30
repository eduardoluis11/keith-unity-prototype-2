using UnityEngine;

/* This will handle the UI of the Inventory.

Source of most of this code: Brackeys from https://youtu.be/YLhj7SfaxSE?si=pdLr_El2GHCs83gl .
*/

public class InventoryUI : MonoBehaviour
{

    public Transform itemsParent;
    
    Inventory inventory;

    InventorySlot[] slots;

    // Use this for initialization
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        // Debug.Log("UPDATING UI");

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

    }
}
