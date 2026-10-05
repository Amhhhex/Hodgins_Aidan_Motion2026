using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Looker : MonoBehaviour
{

    int index;

    public List<Transform> squarePositions = new List<Transform>();

    Transform currentTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        index = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

        //if(Keyboard.current.spaceKey.wasReleasedThisFrame)
        //{
        //    index++;
        //}

        //if(index >= squarePositions.Count)
        //{
        //    index = 0;
        //}

        currentTransform = squarePositions[index];

        for (int i = 0; i < squarePositions.Count; i++)
        {
            float distanceToSquare = Vector3.Distance(transform.position, squarePositions[i].position);

            float distanceToCurrentTransform = Vector3.Distance(transform.position, currentTransform.position);

            if(distanceToSquare < distanceToCurrentTransform)
            {
                currentTransform = squarePositions[i];
            }

        }

        Vector3 currentTarget = currentTransform.position;

        float angleToTarget = VectorMath.VectorToAngle(currentTarget - transform.position);

        Vector3 currentRotation = transform.eulerAngles;

        currentRotation.z = angleToTarget;

        transform.eulerAngles = currentRotation;

        Debug.DrawLine(transform.position, currentTarget, Color.red);


        //Atan2 can be used to convert a vector value into an angle
        //If you just pass Atan2 a vector value, it'll calculate the angle towards that vector AS IF the angle STARTED at (0, 0)
        //So above when I wanted it to look at the closest objects, regardless of its position around it, I needed to get the vector direction
        //so i did currentTarget - transform.position, which is the vector the currentTarget to transform.position
        //This will return an angle value that when passed to the eulerAngles variable in unity, has the correct rotation to always point towards the object



        
    }

    
}
