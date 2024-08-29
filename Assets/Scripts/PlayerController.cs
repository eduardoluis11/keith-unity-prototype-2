using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script will let the player move.

Source of most of this code: Brackeys from https://youtu.be/S2mK6KFdv0I?si=j-YFg86whpVS1Py0 .
 */

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

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
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                // Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                
                motor.MoveToPoint(hit.point);
            }
        }
    }
}
