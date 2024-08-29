using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* This script will let the player move (as in moving from 1 point to the other).

Source of most of this code: Brackeys from https://youtu.be/9tePzyL6dgc?si=rswsagD6YwbvYRs2 .
*/

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update () 
    {
        if (target != null)
        {
            agent.SetDestination(target.position);

        }
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        target = newTarget.transform;
    }

    public void StopFollowingTarget()
    {
        target = null;
    }
}