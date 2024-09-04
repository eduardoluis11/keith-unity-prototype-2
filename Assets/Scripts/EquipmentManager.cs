using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

Source of most of this code: Brackeys from https://youtu.be/d9oLS5hy0zU?si=B5EZx71Tcuk6vs9g .
*/

public class EquipmentManager : MonoBehaviour
{
    #region Singleton

    public static EquipmentManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    Equipment[] currentEquipment;

    // Start is called before the first frame update
    void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip (Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        currentEquipment[slotIndex] = newItem;
    }


}
