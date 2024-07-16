using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float deceleration = 5f;

    private Vector2 currentVelocity;
    private Vector2 inputDirection;

    void FixedUpdate()
    {
        // Get input
        inputDirection.x = Input.GetAxisRaw("Horizontal");
        inputDirection.y = Input.GetAxisRaw("Vertical");


        //sliding logic
        if(inputDirection.x !=0)
        {
           currentVelocity.x = inputDirection.x * moveSpeed;
        }
        else
        {
            
            currentVelocity.x -= currentVelocity.x * Time.deltaTime * deceleration;
        }
        if(inputDirection.y !=0)
        {
           currentVelocity.y = inputDirection.y * moveSpeed;
        }
        else
        {
            
            currentVelocity.y -= currentVelocity.y * Time.deltaTime * deceleration;
        }

        
        // Move the player
        transform.position += (Vector3)currentVelocity * Time.deltaTime;
    }
}
