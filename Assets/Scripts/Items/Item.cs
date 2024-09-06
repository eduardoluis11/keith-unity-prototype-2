using UnityEngine;

// This will let me change scenes
using UnityEngine.SceneManagement;

/* This will handle the interactions with items in general (such as the 4 books for the puzzle).

This will make it so that, if I click on an item in my inventory, it will be equipped to the player, and removed from the 
inventory UI.

I WILL MODIFY THIS CODE SO THAT, once I click on an item, that item will be rendered at the position (1000, 1000, 1000).

Plan:
1) Modify the RemoveFromInventory method to change the item's position to (1000, 1000, 1000) instead of removing it from
the inventory.

2) Ensure the item has a reference to its Transform to change its position.

Source of most of this code: Brackeys from https://youtu.be/HQNl3Ff2Lpo?si=71u8hLxbiQmP9R6h , https://youtu.be/YLhj7SfaxSE?si=zEufI5F7lrAOg6kD .
*/

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    // // This is a "global" variable that will store a generic cube that I will render at (1000, 1000, 1002) when I
    // click on an item in my inventory.
    // // I will use this global variable to also rotate the cube while dragging the mouse.
    // private Transform cube;
    /* Here’s the snippet that prints “Using Helmet of fire” when I use the helmet of fire from my inventory.

    However: how does the “name” variable change from “New Item” to “Helmet of Fire” when calling the Use() function?

    This is the script that creates the scriptable objects. Is it because I assigned “Helmet of fire” as the “name”
    property in the unity editor for that specific item? Did that overwrite the name “New Item” to “Helmet of Fire”
    when I end up sign the item?

    If the book is called “Atlas Shrugged”, I should change to the “Atlas Shrugged” scene. Heck, I could just modify
    the Use() function inside of the Item.cs script so that I would create a new variable called “name of the book”. Or
    heck, I could simply put “Atlas Shrugged”, “We the living”, etc, to the item’s name in the Unity editor. Then, i
    would put a switch case statement, or even an if statement, that says that, if the item selected is “Atlas
    Shrugged”, to change to the “Atlas Shrugged” scene. And I would do the exact same thing with the remaining 3 books.

    */
    public virtual void Use ()
    {
        // Use the item
        // Something might happen

        Debug.Log("Using " + name + " from the Use() function from the Item.cs script.");

        // If the item is a book, change to the respective scene that corresponds to that book.
        if (name == "Atlas Shrugged")
        {
            SceneManager.LoadScene("AtlasShruggedInspectorViewer");
        }
        else if (name == "We the Living")
        {
            SceneManager.LoadScene("WetheLivingInspectorViewer");
        }
        else if (name == "Anthem")
        {
            SceneManager.LoadScene("AnthemInspectorViewer");
        }
        else if (name == "The Fountainhead")
        {
            SceneManager.LoadScene("TheFountainheadInspectorViewer");
        }
    }

    // This will remove the item from the inventory when the player clicks on it.
    // I WILL MODIFY THIS SO THAT the item will be rendered at the position (1000, 1000, 1000) instead of being removed
    // from the inventory.
    /* This removes the selected item from the inventory when you use it.

    I added a snippet that changed to user to the "We the living" scene when the player clicks on any item in the
    inventory. However, I removed this feature because I now know how to change to each book's respective scene
    when I click on the respective book.
    */
    public void RemoveFromInventory ()
    // public void RemoveFromInventory(Transform itemTransform)    // THIS MAY NOT WORK, SO DELETE LATER
    {
        // This removes the item from the inventory.
        // Activate later?
        Inventory.instance.Remove(this);


        // This will create a generic cube at the position (1000, 1000, 1002) when I click on an item in my inventory.
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        // cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(1000, 1000, 1002);
        // End of the code to create a generic cube at the position (1000, 1000, 1002).

        // I NO LONGER NEED THIS.
        //        // For the time being, let's change to the "We the living" scene when the player clicks on any item
        //        // in the inventory.
        //        SceneManager.LoadScene("WeTheLivingInspectorViewer");

        //        // Assuming the item has a reference to its Transform
        //        Transform itemTransform = this.transform;
        //        itemTransform.position = new Vector3(1000, 1000, 1000);

        //     // THIS MAY NOT WORK, SO DELETE LATER.
        //    // This is supposed to make the item to be rendered at the position (1000, 1000, 1000).
        //     itemTransform.position = new Vector3(1000, 1000, 1000);
    }
}