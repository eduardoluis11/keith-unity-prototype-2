using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script for handling equipment items.

This will make it so that, if I click on an item in my inventory, it will be equipped to the player, and removed from the 
inventory UI.

I WILL MODIFY THIS CODE SO THAT, once I click on an item, that item will be rendered at the position (1000, 1000, 1000).

Source of most of this code: Brackeys from https://youtu.be/d9oLS5hy0zU?si=80WafnTJLHsbbReg

*/

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{

    public EquipmentSlot equipSlot;

    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }

}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet }
