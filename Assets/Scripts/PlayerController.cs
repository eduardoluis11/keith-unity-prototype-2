using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script will let the player move.

Source of most of this code: Brackeys from https://youtu.be/S2mK6KFdv0I?si=j-YFg86whpVS1Py0 , https://youtu.be/9tePzyL6dgc?si=4DXgIfg0ETg8TWuu 
 */

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    public Interactable focus;

    public LayerMask movementMask;

    Camera cam;
    PlayerMotor motor;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {

        // If we press left mouse
        if (Input.GetMouseButtonDown(0))
        {
            // We create a ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the ray hits
            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);

                RemoveFocus();
            }
        }

        // If we press the right mouse
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
            
                if (interactable != null)
                {

                    SetFocus(interactable);
                }
            }
        }
    }


    void SetFocus(Interactable newFocus)
    {
        focus = newFocus;
        // motor.FollowTarget(newFocus);
    }

    void RemoveFocus()
    {
        focus = null;
        // motor.StopFollowingTarget();
    }

}