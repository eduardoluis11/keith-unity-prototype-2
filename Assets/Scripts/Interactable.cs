using UnityEngine;

/* This will handle the interactable objects in the game.

Source of most of this code: Brackeys from https://youtu.be/9tePzyL6dgc?si=FOzPN00egvGVC0As
*/

public class Interactable : MonoBehaviour
{

    public float radius = 3f;

    bool isFocus = false;
    Transform player;

    void Update ()
    {
        if (isFocus)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                Debug.Log("INTERACTING");
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
    }

    public void onDefocused()
    {
        isFocus = false;
        player = null;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}