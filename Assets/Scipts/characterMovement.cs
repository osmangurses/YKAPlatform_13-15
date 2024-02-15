using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class characterMovement : MonoBehaviour
{
    public float characterSpeed=5;
    public int movementRotate=0;
    public float jumpForce=10;
    public float raycastDistance = 1f;
    public Vector2 rayOffset;
    public bool isGrounded=false;
    public GameObject characterSpriteRenderer;
    
    private CharacterAnimController animController;
    private Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animController = GetComponent<CharacterAnimController>();
    }

     private void Update()
     {
         transform.position += Vector3.right * characterSpeed * Time.deltaTime * movementRotate;
         GroundedRayControl();
     }
   

    void GroundedRayControl()
    {
        Vector2 raycastOrigin = (Vector2)transform.position+rayOffset;
        Vector2 raycastDirection = Vector2.down;
        Debug.DrawRay(raycastOrigin, raycastDirection * raycastDistance, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, raycastDirection, raycastDistance);
        if (hit.collider != null && hit.collider.gameObject.tag=="Ground")
        {
            isGrounded = true;
            animController.StopJumpAnim();
        }
        else
        {
            isGrounded=false;
            animController.PlayJumpAnim();
        }
    }
    public void ChangeMovementRotate(int rotate)
    {
        movementRotate = rotate;
        if (movementRotate==-1)
        {
            characterSpriteRenderer.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (movementRotate==1)
        {
            characterSpriteRenderer.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (movementRotate==0)
        { animController.StopRunAnim(); }
        else
        { animController.PlayRunAnim();}
    }
    public void JumpCharacter()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
       
    }
}
