//WEEK 10:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRB;

    public float maxSpeed;

    public float accelerationTime;
    private float acceleration;

    public float distance;

    Vector3 currentVelocity;

    public enum FacingDirection
    {
        left, right
    }

    // Start is called before the first frame update
    void Start()
    {
        acceleration = maxSpeed / accelerationTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        //The input from the player needs to be determined and then passed in the to the MovementUpdate which should
        //manage the actual movement of the character.
        Vector2 playerInput = new Vector2();

        if(Keyboard.current.rightArrowKey.isPressed)
        {
            playerInput.x += 1f;
        }
        if(Keyboard.current.leftArrowKey.isPressed)
        {
            playerInput.x -= 1f;
        }

        MovementUpdate(playerInput);
    }

    private void MovementUpdate(Vector2 playerInput)
    {
        Vector2 newVelocity = playerRB.linearVelocity;
        if (playerInput.x != 0)
        {
            //accelerate
            newVelocity += playerInput * acceleration * Time.deltaTime;
        }
        else
        {
            //????
            
        }
        playerRB.linearVelocity = newVelocity;

    }

    public bool IsWalking()
    {
        if (playerRB.linearVelocity.x != 0)
        {
            return true;
        }

        return false;
    }
    public bool IsGrounded()
    {
        int layer = LayerMask.GetMask("Ground");

        bool didItHit = Physics2D.Raycast(playerRB.transform.position, Vector2.down, distance, layer);

        Debug.Log(didItHit.ToString());

        if (didItHit)
        {
            return true;
        }

        else
        {
            return false;
        }

        
    }

    public FacingDirection GetFacingDirection()
    {
        if(playerRB.linearVelocity.x > 0)
        {
            return FacingDirection.right;
        }

        else
        {
            return FacingDirection.left;
        }
    }
}

