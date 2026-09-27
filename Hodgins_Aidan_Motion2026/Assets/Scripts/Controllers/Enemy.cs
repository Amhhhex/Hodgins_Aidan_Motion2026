using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{

    public Vector3 currentVelocity;

    public float maxSpeed;
    public float accelerationTime;

    public float currentAcceleration;
    public float decelerationTime;

    public float currentDeceleration;

    public float acceleration;

    public float boostCooldown;

    public float boostSpeed;

    private void Start()
    {
        //To get our desired acceleration we need two variables, a max speed we want to achieve, and an amount of time it will take to reach that speed
        //By dividing the max speed by the acceleration time we will get a value, that when added all together over time, will equal the max speed
        //This value can be called our current Acceleration
        currentAcceleration = maxSpeed / accelerationTime;

        //To get the deceleration we do the exact same thing, but instead we want the time value to represent how long until we want it to reach a full stop
        //The calculation is the same, just with the time value replaced with our decelerationTime. By dividing the max speed by this time, we get the currentDeceleration for the player
        currentDeceleration = maxSpeed / decelerationTime;
    }

    private void Update()
    {
        EnemyMovement();


    }

    void EnemyMovement()
    {
        Vector3 accelerationVector = Vector3.zero;

        boostCooldown -= Time.deltaTime;

        if (Keyboard.current.wKey.isPressed)
        {
            accelerationVector += new Vector3(0, 1, 0);
        }
        if (Keyboard.current.sKey.isPressed)
        {
            accelerationVector += new Vector3(0, -1, 0);

        }
        if (Keyboard.current.aKey.isPressed)
        {
            accelerationVector += new Vector3(-1, 0, 0);

        }
        if (Keyboard.current.dKey.isPressed)
        {
            accelerationVector += new Vector3(1, 0, 0);

        }

       

        if (currentVelocity.magnitude > maxSpeed || (!Keyboard.current.wKey.isPressed && !Keyboard.current.dKey.isPressed && !Keyboard.current.aKey.isPressed && !Keyboard.current.sKey.isPressed))
        {
            currentVelocity -= currentVelocity.normalized * currentDeceleration * Time.deltaTime;

        }

        currentVelocity += accelerationVector.normalized * currentAcceleration * Time.deltaTime;





        boostCooldown = Mathf.Clamp(boostCooldown, 0, 5f);

        if(Keyboard.current.spaceKey.isPressed && boostCooldown <= 0f)
        {
            currentVelocity += accelerationVector.normalized * boostSpeed * Time.deltaTime;
            boostCooldown = 5f;
        }



        //if (currentVelocity.magnitude > maxSpeed)
        //{
        //    currentVelocity -= currentVelocity.normalized * currentDeceleration * Time.deltaTime;

        //}

        Debug.Log("Current Velocity: " + currentVelocity.magnitude);   

        transform.position = transform.position + currentVelocity * Time.deltaTime;

        //Since everything is calculated on a framerate basis, when we want something to occur over a period of time we want to use Time.deltaTime to have that happen
        //But if we want movement to be instanious, like teleporting, we don't want to use Time.deltaTime so that it happens instantly
        //Within this project the Warping function for the player is an example of when not to use it, since we want the player to move instantly
    }

}
