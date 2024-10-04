using UnityEngine;

using UnityEngine.SceneManagement;  // This is needed to change scenes. This is needed to change to the PuzzleWallScene.

/* This will handle the interactable objects in the game. That is, if you right click on an object, you could pick it up, get close to it,
or even activate the puzzle in the wall where you'll have to place the 4 books in chronological order. This script will be attached to the
objects that you can interact with.

Source of most of this code: Brackeys from https://youtu.be/9tePzyL6dgc?si=FOzPN00egvGVC0As
*/

public class Interactable : MonoBehaviour
{

    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;

    /* This will print out the name of the object that you're interacting with in the console of Unity's Editor.
    
    This method is meant to be overwritten by the child classes.
    */
    public virtual void Interact ()
    {
        // This method is meant to be overwritten
        Debug.Log("Interacting with " + transform.name);
    }

    /* This will move the player towards the interactable object if you right click on it. If the player is close enough to the object, then
    the Interact() method / function will be called.

    I will add an extra condition here that will make it so that, if you interact with the Puzzle Wall, you will change to a new scene, which will
    be the scene in which you will have to solve the 4-book puzzle. I can put an ‘if’ statement that says ‘if the object’s name is “Puzzle Wall”, 
    change to another scene.

    To add the extra condition to change the scene when interacting with the "Puzzle Wall", you can modify the Update
    method as follows:

    1) Add an if statement to check if the object's name is "Puzzle Wall".

    2) Use SceneManager.LoadScene to change to the new scene.

    Instead of the puzzle wall with the drag and drop features, I will intead use the Quiz Game Scene as the Puzzle Wall. That is, you will have to
    answer questions in a Quiz in order to solve the puzzle.
    */
    void Update ()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                // If the object's name is "Puzzle Wall", then change to the Puzzle Wall Scene.
                if (transform.name == "Puzzle Wall")
                {
                    SceneManager.LoadScene("QuizPuzzleWall");
                }

                // If you're interacting with any other object, I will execute the Interact() method.
                else
                {

                    // Debug.Log("INTERACTING");
                    Interact();
                }
                hasInteracted = true;


            }

            
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void onDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}