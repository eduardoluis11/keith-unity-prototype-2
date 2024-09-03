using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

/* This script will let me rotate the 3D model in the inspector window of the 2nd Canvas by clicking and dragging on it in the 
3D Inspector Viewer.

Source of most of this code: Code Monkey from https://youtu.be/tJ_ycboPFmY?si=eLVAlTHsSYgCOLun .

I need to add the "IDragHandler" keyword, or otherwise, nothing will happen if I click and drag the mouse.

I also need to add the "OnDrag" method, which will be called when the mouse is dragged.
*/

public class Item3DViewer : MonoBehaviour, IDragHandler
{

    // This does something when I click and drag the mouse inside the 2nd Canvas.
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");

        // itemPrefab.eulerAngles = new Vector3(
        //     itemPrefab.eulerAngles.x + (eventData.delta.y * 0.1f),
        //     itemPrefab.eulerAngles.y - (eventData.delta.x * 0.1f),
        //     0
        // );

        // // Rotates whatever Game Object has this script attached (like the 2D Canvas).
        // // This rotates the 2nd Canvas, SO I NEED TO COMMENT THIS OUT TO ELIMINATE THIS SNIPPET TO PREVENT THAT BUG.
        // if (eventData.button == PointerEventData.InputButton.Left)
        // {
        //     transform.Rotate(Vector3.up, -eventData.delta.x, Space.World);
        //     transform.Rotate(Vector3.right, eventData.delta.y, Space.World);
        // }
    }

}
