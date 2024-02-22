using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanyeAIMovement : MonoBehaviour
{
    public Vector2 ray1Offset, ray2Offset;
    public float raycast1Distance, raycast2Distance;
    public float kanyeMovementSpeed;
    private bool goLeft, goRight;

    private void Update()
    {
        AICharacterFollow();

        
    }
    private void AICharacterFollow()
    {
        Vector2 raycast1Origin = (Vector2)transform.position + ray1Offset;
        Vector2 raycast1Direction = Vector2.left;
        Debug.DrawRay(raycast1Origin, raycast1Direction * raycast1Distance, Color.red);
        RaycastHit2D hit1 = Physics2D.Raycast(raycast1Origin, raycast1Direction, raycast1Distance);

        if (hit1.collider != null && hit1.collider.gameObject.tag == "Player")
        {
            goLeft = true;
            goRight = false;
        }
        else
        {
            goLeft = false;
        }

        Vector2 raycast2Origin = (Vector2)transform.position + -ray1Offset;
        Vector2 raycast2Direction = Vector2.right;
        Debug.DrawRay(raycast2Origin, raycast2Direction * raycast1Distance, Color.red);
        RaycastHit2D hit2 = Physics2D.Raycast(raycast2Origin, raycast2Direction, raycast1Distance);

        if (hit2.collider != null && hit2.collider.gameObject.tag == "Player")
        {
            goLeft = false;
            goRight = true;
        }
        else
        {
            goRight = false;
        }

        if (goLeft)
        {
            transform.position += Vector3.left * kanyeMovementSpeed * Time.deltaTime;
        }
        else if (goRight)
        {
            transform.position += Vector3.right * kanyeMovementSpeed * Time.deltaTime;
        }
    }
   
}
