using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script for handling equipment items.

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

    }

}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet }
