using System.Data.SqlTypes;
using UnityEngine;

/* This will handle the interactions with items in general (such as the 4 books for the puzzle).

Source of most of this code: Brackeys from https://youtu.be/HQNl3Ff2Lpo?si=71u8hLxbiQmP9R6h .
*/

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
}
