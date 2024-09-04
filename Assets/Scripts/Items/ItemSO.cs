using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This wil help me inspect an item in a 3D viewer (like in Skyrim or in Fallout New Vegas.)

Source of most of this code: Code Monkey from https://www.youtube.com/watch?v=tJ_ycboPFmY 
*/

public class ItemSO : ScriptableObject
{

    public Sprite sprite;

    // This makes me able to assign a 3D Game Object Prefab to the Scriptable Object.
    public Transform prefab;

}
