using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script for handling equipment items.

This will make it so that, if I click on an item in my inventory, it will be equipped to the player, and removed from the 
inventory UI.

I WILL MODIFY THIS CODE SO THAT, once I click on an item, that item will be rendered at the position (1000, 1000, 1000).


I will Modify the Equipment class to detect a 3D Game Object or a prefab Game Object instead of a SkinnedMeshRenderer.
That way, I should be able to assign 3D Game Objects to Scriptable Objects and render them in the scene.

Source of most of this code: Brackeys from https://youtu.be/d9oLS5hy0zU?si=80WafnTJLHsbbReg , Sebastian Lague from https://youtu.be/ZBLvKR2E62Q?si=B2hK3wcZjWCbYFm4

*/

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{

    public EquipmentSlot equipSlot;

    //    // This will be the mesh that will be rendered when the item is equipped.
    //    // I SHOULD CHANGE THIS TO A 3D MODEL OF THE ITEM.
    //    public SkinnedMeshRenderer mesh;

    // public GameObject gameObject3D; // Changed to detect a 3D Game Object. THIS GIVES ME A BUG.
    // public GameObject prefab; // Reference to the prefab

    // This makes me able to assign a 3D Game Object Prefab to the Scriptable Object, and its coordinates.
    public Transform prefab;



    public int armorModifier;
    public int damageModifier;

    // Does this let me use an item when I click on it? If so, I will modify this to change the scene to
    // the corresponding scene for selected books (i.e: if you choose "We the living", you will go to the "We the
    // living" scene).
    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }

}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet }
