using UnityEngine;

/* This will let me pick up the items (it will make them disappear when I touch them).

Source of most of this code: Brackeys from https://youtu.be/HQNl3Ff2Lpo?si=Znaj_6rB8QTZWGDi .
*/

public class ItemPickup : Interactable
{

    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);


        // Add to inventory (it makes the item disappear when I touch it)
        if (wasPickedUp)
            Destroy(gameObject);
    }
}
