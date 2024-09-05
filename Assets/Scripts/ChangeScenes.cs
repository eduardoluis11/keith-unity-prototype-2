using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This will let me change scenes
using UnityEngine.SceneManagement;

/* This script will be used to change scenes. 

I will use it so that, if you're in the 3D Inspector Viewer in any of the 4 scenes of the 4 books, this will allow you to go back to the main 
scene to go back to the main game (being the player moving around).

I will use this script in the 4 book scenes. I will attach it to the Text object that says "Press Esc to go back". 

If the player presses the "Esc" key, it will take them back to the main scene.
*/

public class ChangeScenes : MonoBehaviour
{
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame.
    // This will detect if the player presses the "Esc" key. If they do, it will take them back to the main scene.
    void Update()
    {
        // If the player presses the "Esc" key, it will take them back to the main scene.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // This will take the player back to the main scene.
            SceneManager.LoadScene("Main");
        }
    }
}
