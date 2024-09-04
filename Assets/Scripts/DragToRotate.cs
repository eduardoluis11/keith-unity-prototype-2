using UnityEngine;

/* To create a script that allows you to rotate a cube by clicking and dragging on it, you can follow these steps. This script will use mouse 
input to detect dragging and apply rotation to the cube based on the drag direction.


Explanation: 

rotationSpeed: Controls how fast the cube rotates based on mouse movement.

isDragging: A boolean to track whether the cube is currently being dragged.

lastMousePosition: Stores the position of the mouse during the last frame to calculate the movement delta.

OnMouseDown(): Starts the dragging process when the cube is clicked.

OnMouseUp(): Stops the dragging process when the mouse button is released.

transform.Rotate(): Rotates the cube based on the difference in mouse position between frames.

Steps to Use the Script

Attach the Script: Attach this DragToRotate script to your cube GameObject in the scene.

Configure Rotation Speed: You can adjust the rotationSpeed variable in the Unity Inspector to control how fast the cube rotates.


How It Works

The script detects when you click on the cube by using a raycast from the mouse position.

While dragging, the cube rotates according to the mouse movement. The horizontal mouse movement (X-axis) rotates the cube around its vertical axis 
(Y-axis), and the vertical mouse movement (Y-axis) rotates the cube around its horizontal axis (X-axis).

The rotation is applied in world space (Space.World) to maintain a consistent rotation direction regardless of the cube's current orientation.

This script will give you an interactive cube that can be rotated by dragging it with the mouse.

I could make a simple book in the newest version of Blender, and put “atlas Shrugged” at the front, and “1957” at the back. And I could do
the same for the rest of Ayn Rand's novels.
*/

public class DragToRotate : MonoBehaviour
{
    public float rotationSpeed = 100f;  // Speed of the rotation

    private bool isDragging = false;
    private Vector3 lastMousePosition;

    void Update()
    {
        // Check if the left mouse button is pressed down
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the click is on the cube
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    isDragging = true;
                    lastMousePosition = Input.mousePosition;
                }
            }
        }

        // Check if the left mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // Rotate the cube based on mouse movement
        if (isDragging)
        {
            Vector3 deltaMousePosition = Input.mousePosition - lastMousePosition;
            float rotationX = deltaMousePosition.y * rotationSpeed * Time.deltaTime;
            float rotationY = -deltaMousePosition.x * rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up, rotationY, Space.World);
            transform.Rotate(Vector3.right, rotationX, Space.World);

            lastMousePosition = Input.mousePosition;
        }
    }
}
